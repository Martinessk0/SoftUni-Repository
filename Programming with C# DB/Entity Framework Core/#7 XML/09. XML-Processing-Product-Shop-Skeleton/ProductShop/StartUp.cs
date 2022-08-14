using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System;
using ProductShop.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var contex = new ProductShopContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            //var xmlInput = File.ReadAllText("../../../Datasets/users.xml");
            //var result = ImportUsers(contex, xmlInput);

            //var xmlInput = File.ReadAllText("../../../Datasets/products.xml");
            //var result = ImportProducts(contex, xmlInput);

            //var xmlInput = File.ReadAllText("../../../Datasets/categories.xml");
            //var result = ImportCategories(contex, xmlInput);

            //var xmlInput = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var result = ImportCategoryProducts(contex, xmlInput);

            //var result = GetProductsInRange(contex);

            //var result = GetSoldProducts(contex);

            //var result = GetCategoriesByProductsCount(contex);

            var result = GetUsersWithProducts(contex);

            System.Console.WriteLine(result);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
               .ToList()
               .Where(x => x.ProductsSold.Any())
               .OrderByDescending(x => x.ProductsSold.Count)
               .Select(x => new GetUsersProductsModel
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Age = x.Age,
                   SoldProducts = new UserSoldProduct
                   {
                       Count = x.ProductsSold.Count,
                       Products = x.ProductsSold.Select(s => new SoldProductsOutputModel
                       {
                           Name = s.Name,
                           Price = s.Price
                       })
                       .OrderByDescending(s => s.Price)
                       .ToList()
                   }
               })
               .Take(10)
               .ToList();

            var mainResult = new FullModel
            {
                Count = context.Users.Where(x => x.ProductsSold.Any()).Count(),
                Users = users
            };

            return XmlConverter.Serialize(mainResult, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb=new StringBuilder();

            using (StringWriter sw=new StringWriter(sb))
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDto[]), xmlRoot);
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add(string.Empty, string.Empty);

                var categories = context.Categories
                .Select(x => new CategoryDto
                {
                    name = x.Name,
                    count = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts.Average(c => c.Product.Price),
                    totalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.totalRevenue)
                .ToArray();

                xmlSerializer.Serialize(sw, categories, xmlns);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw=new StringWriter(sb))
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
                XmlSerializerNamespaces xmls = new XmlSerializerNamespaces();
                xmls.Add(string.Empty, string.Empty);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSoldProductDto[]), xmlRoot);

                var users = context.Users
               .Where(x => x.ProductsSold.Count() > 0)
               .Select(x => new UserSoldProductDto
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   soldProducts = x.ProductsSold
                   .Select(sp => new SoldProductDto
                   {
                       name=sp.Name,
                       price=sp.Price
                   }).ToArray()
               })
               .OrderBy(x => x.lastName)
               .ThenBy(x => x.firstName)
               .Take(5)
               .ToArray();

                xmlSerializer.Serialize(sw, users, xmls);

            }
            return sb.ToString().TrimEnd();
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
                XmlSerializerNamespaces xmls = new XmlSerializerNamespaces();
                xmls.Add(string.Empty, string.Empty);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductSoldDto[]), xmlRoot);

                ProductSoldDto[] products = context.Products
               .Where(p => p.Price >= 500 && p.Price <= 1000)
               .Select(p => new ProductSoldDto()
               {
                   Name = p.Name,
                   Price = p.Price,
                   Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
               })
               .OrderBy(p => p.Price)
               .Take(10)
               .ToArray();

                xmlSerializer.Serialize(sw, products,xmls);
            }
            return sb.ToString().TrimEnd();
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]), xmlRoot);
            using (StringReader str = new StringReader(inputXml))
            {
                CategoryProductImportDto[] dtos = (CategoryProductImportDto[])xmlSerializer.Deserialize(str);
                ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
                foreach (var categoryProduct in dtos)
                {
                    CategoryProduct cp = new CategoryProduct()
                    {
                        CategoryId = categoryProduct.CategoryId,
                        ProductId = categoryProduct.ProductId
                    };
                    categoryProducts.Add(cp);
                }
                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();

                return $"Successfully imported {categoryProducts.Count}";
            }
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryImportDto[]), root);
            using (StringReader str = new StringReader(inputXml))
            {
                CategoryImportDto[] dtos = (CategoryImportDto[])serializer.Deserialize(str);
                ICollection<Category> categories = new List<Category>();
                foreach (var category in dtos)
                {
                    Category c = new Category()
                    {
                        Name = category.Name,
                    };
                    categories.Add(c);
                }
                context.Categories.AddRange(categories);
                context.SaveChanges();

                return $"Successfully imported {categories.Count}";
            }
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductImportDto[]), xmlRoot);

            using (StringReader str = new StringReader(inputXml))
            {
                ProductImportDto[] dtos = (ProductImportDto[])xmlSerializer.Deserialize(str);
                ICollection<Product> products = new List<Product>();
                foreach (var product in dtos)
                {
                    Product p = new Product()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        SellerId = product.SellerId,
                        BuyerId = product.BuyerId
                    };
                    products.Add(p);
                }
                context.Products.AddRange(products);
                context.SaveChanges();

                return $"Successfully imported {products.Count}";
            }
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserImportDto[]), xmlRoot);

            using (StringReader str = new StringReader(inputXml))
            {
                UserImportDto[] dtos = (UserImportDto[])xmlSerializer.Deserialize(str);
                ICollection<User> users = new HashSet<User>();
                foreach (var userDto in dtos)
                {
                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = int.Parse(userDto.Age)
                    };
                    users.Add(user);
                }
                context.Users.AddRange(users);
                context.SaveChanges();
                return $"Successfully imported {users.Count}";
            }
        }
    }
}