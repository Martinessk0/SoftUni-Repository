using AutoMapper;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\suppliers.xml");
            //var result = ImportSuppliers(context, inputXml);

            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\parts.xml");
            //var result = ImportParts(context, inputXml);

            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
            //var result = ImportCars(context, inputXml);

            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
            //var result = ImportCustomers(context, inputXml);

            //var inputXml = File.ReadAllText(@"..\..\..\Datasets\sales.xml");
            //var result = ImportSales(context, inputXml);

            //var result = GetCarsWithDistance(context);

            //var result = GetCarsFromMakeBmw(context);

            //var result = GetLocalSuppliers(context);

            //var result = GetCarsWithTheirListOfParts(context);

            //var result = GetTotalSalesByCustomer(context);

            var result = GetSalesWithAppliedDiscount(context);

            System.Console.WriteLine(result);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SaleExportDto()
                {
                    Car = new CarAttributeExportDto()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(c => c.Part.Price),
                    PriceWithDiscount = x.Car.PartCars.Sum(c => c.Part.Price) - x.Car.PartCars.Sum(c => c.Part.Price) * x.Discount / 100m,

                })
                .ToArray();

            var xmlResult = XmlConverter.Serialize(sales, "sales");
            return xmlResult;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string root = "customers";
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new CustomerExportDto()
                {
                    FullName = x.Name,
                    CarsCount = x.Sales.Count(),
                    PriceSum = x.Sales.Select(x => x.Car).SelectMany(x => x.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.PriceSum)
                .ToList();

            var xmlResult = XmlConverter.Serialize(customers, root);
            return xmlResult;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string root = "cars";
            var cars = context.Cars
                .Select(x => new CarPartExportDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(p => new PartsExportDto()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var xmlResult = XmlConverter.Serialize(cars, root);
            return xmlResult;

        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string root = "suppliers";
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SupplierExportDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();
            var xmlResult = XmlConverter.Serialize(suppliers, root);
            return xmlResult;
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string root = "cars";
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmwCarExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDisctance = c.TravelledDistance,
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDisctance)
                .ToArray();
            var xmlResult = XmlConverter.Serialize(cars, root);
            return xmlResult;
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string root = "cars";
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new CarExportDto()
                {
                    make = c.Make,
                    model = c.Model,
                    travelleddistance = c.TravelledDistance,
                })
                .OrderBy(x => x.make)
                .ThenBy(x => x.model)
                .Take(10)
                .ToList();
            var xmlResult = XmlConverter.Serialize(cars, root);
            return xmlResult;
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";
            InitializeAutoMapper();

            var carsIds = context.Cars
              .Select(x => x.Id)
              .ToArray();

            var dtoSales = XmlConverter.Deserializer<SaleImportDto>(inputXml, root);
            var filteredSales = dtoSales.Where(x => carsIds.Contains(x.CarId));
            var mappedSales = mapper.Map<IEnumerable<Sale>>(filteredSales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            InitializeAutoMapper();

            var dtoCustomers = XmlConverter.Deserializer<CustomerImportDto>(inputXml, root);
            var mappedCustomer = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(mappedCustomer);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomer.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var dtoCars = XmlConverter.Deserializer<CarImportDto>(inputXml, root);
            var allParts = context.Parts.Select(x => x.Id).ToList();

            var cars = new List<Car>();

            foreach (var currcar in dtoCars)
            {
                var distinctedParts = currcar.CarPartImportDto.Select(x => x.Id).Distinct();
                var parts = distinctedParts
                    .Intersect(allParts);

                var car = new Car
                {
                    Make = currcar.Make,
                    Model = currcar.Model,
                    TravelledDistance = currcar.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";
            InitializeAutoMapper();
            var suppliesIds = context.Suppliers
              .Select(x => x.Id)
              .ToArray();

            var dtoParts = XmlConverter.Deserializer<PartImportDto>(inputXml, root);
            var filteredParts = dtoParts.Where(p => suppliesIds.Contains(p.SupplierId));
            var parts = mapper.Map<IEnumerable<Part>>(filteredParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";
            InitializeAutoMapper();

            var dtoSuppliers = XmlConverter.Deserializer<SupplierImportDto>(inputXml, root);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}