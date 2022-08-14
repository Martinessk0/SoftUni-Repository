using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var contex = new ProductShopContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            //var userJsonAsString = File.ReadAllText(@"..\..\..\Datasets\users.json");
            //var result = ImportUsers(contex, userJsonAsString);

            //var productJsonAsString = File.ReadAllText(@"..\..\..\Datasets\products.json");
            //var result = ImportProducts(contex, productJsonAsString);

            //var categoryJsonAsString = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            //var result = ImportCategories(contex, categoryJsonAsString);

            //var categoryAndProductJsonAsString = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");
            //var result = ImportCategoryProducts(contex, categoryAndProductJsonAsString);

            //var result = GetProductsInRange(contex);

            //var result = GetSoldProducts(contex);

            //var result = GetCategoriesByProductsCount(contex);

            var result = GetUsersWithProducts(contex);

            Console.WriteLine(result);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                        .Where(p => p.BuyerId != null).Count(),
                        Products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();
            var resultObject = new
            {
                usersCount = users.Count,
                users = users
            };
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };
            var jsonResult = JsonConvert.SerializeObject(resultObject, jsonSettings);
            return jsonResult;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var catagories = context.Categories
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(a => a.Product.Price).ToString("f2"),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var jsonResult = JsonConvert.SerializeObject(catagories, jsonSettings);
            return jsonResult;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(x => x.BuyerId != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(b => new
                    {
                        Name = b.Name,
                        Price = b.Price,
                        BuyerFirstName = b.Buyer.FirstName,
                        BuyerLastName = b.Buyer.LastName,
                    })
                    .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u =>u.FirstName)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            var jsonResult = JsonConvert.SerializeObject(users, jsonSettings);
            return jsonResult;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };
            var jsonResult = JsonConvert.SerializeObject(products,jsonSettings);
            return jsonResult;
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var categoriesAndProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);
            var mappedCategoriesAndProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesAndProducts);

            context.CategoryProducts.AddRange(mappedCategoriesAndProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoriesAndProducts.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
                .Where(x => x.Name != null);
            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);
            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}