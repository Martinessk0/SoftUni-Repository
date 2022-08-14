using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarDealer.DTO;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var contex = new CarDealerContext();
            //contex.Database.EnsureDeleted();
            //contex.Database.EnsureCreated();

            //var suppliersJsonAsString = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
            //var result = ImportSuppliers(contex, suppliersJsonAsString);

            //var partsJsonAsString = File.ReadAllText(@"..\..\..\Datasets\parts.json");
            //var result = ImportParts(contex, partsJsonAsString);

            //var carsJsonAsString = File.ReadAllText(@"..\..\..\Datasets\cars.json");
            //var result = ImportCars(contex, carsJsonAsString);

            //var carsJsonAsString = File.ReadAllText(@"..\..\..\Datasets\customers.json");
            //var result = ImportCustomers(contex, carsJsonAsString);

            //var salesJsonAsString = File.ReadAllText(@"..\..\..\Datasets\sales.json");
            //var result = ImportSales(contex, salesJsonAsString);

            //var result = GetOrderedCustomers(contex);

            //var result = GetCarsFromMakeToyota(contex);

            //var result = GetLocalSuppliers(contex);

            //var result = GetCarsWithTheirListOfParts(contex);

            //var result = GetTotalSalesByCustomer(contex);

            var result = GetSalesWithAppliedDiscount(contex);

            Console.WriteLine(result);
            
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount,
                    price = x.Car.PartCars
                        .Sum(y => y.Part.Price)
                        .ToString("f2"),
                    priceWithoutDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100).ToString("f2")
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return jsonResult;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
               .Where(x => x.Sales.Count() > 0)
               .Select(x => new
               {
                   fullName = x.Name,
                   boughtCars = x.Sales.Count(),
                   spentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(s => s.Part.Price))
               })
               .OrderByDescending(x => x.spentMoney)
               .ThenByDescending(x => x.boughtCars)
               .ToList();

            var jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsonResult;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance,
                    },
                    parts =
                        x.PartCars.Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("f2")
                        })
                })
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return jsonResult;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();
            var jsonResult=JsonConvert.SerializeObject(suppliers,Formatting.Indented);

            return jsonResult;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);

            var jsonResult=JsonConvert.SerializeObject(cars,Formatting.Indented);

            return jsonResult;
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy"
            };

            var jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented, settings);
            return jsonResult;
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var sales = JsonConvert.DeserializeObject<IEnumerable<SaleDto>>(inputJson);
            var mappedSales = mapper.Map<IEnumerable<Sale>>(sales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        { 
            InitializeAutoMapper();
            var customers=JsonConvert.DeserializeObject<IEnumerable<CustomerDto>>(inputJson);   
            var mappedCustomers =mapper.Map<IEnumerable<Customer>>(customers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<CarDto>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in dtoCars)
            {
                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.travelledDstance,
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    currCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(currCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var suppliesIds = context.Suppliers
               .Select(x => x.Id)
               .ToArray();
            var parts = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJson)
                .Where(p => suppliesIds.Contains(p.SupplierId));
            var mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierDto>>(inputJson);
            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
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