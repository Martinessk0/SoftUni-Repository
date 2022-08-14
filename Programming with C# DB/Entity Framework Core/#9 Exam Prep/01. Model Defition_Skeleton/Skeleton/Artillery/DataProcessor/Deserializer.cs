namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.XmlHelper;
    using AutoMapper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        static IMapper mapper;
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CountryDto[]), xmlRoot);

            using (StringReader sr=new StringReader(xmlString))
            {
                CountryDto[] dtos = (CountryDto[])xmlSerializer.Deserialize(sr);
                ICollection<Country> countries = new HashSet<Country>();
                foreach (var c in dtos)
                {
                    if (IsValid(c))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if ((c.ArmySize < 50_000 || c.ArmySize > 10_000_000))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if ((c.CountryName.Length < 4 || c.CountryName.Length > 60))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    countries.Add(new Country()
                    {
                        CountryName = c.CountryName,
                        ArmySize = c.ArmySize
                    });
                    sb.AppendLine($"Successfully import {c.CountryName} with {c.ArmySize} army personnel.");
                }

                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }
        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
           var sb = new StringBuilder();
           const string root = "Manufacturers";
            using (StringReader str = new StringReader(xmlString))
            {
                var dtos = XmlConverter.Deserializer<ManufacturerDto>(xmlString, root);
                ICollection<Manufacturer> manufacturers = new HashSet<Manufacturer>();
                foreach (var m in dtos)
                {
                    if (IsValid(m))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if (m.ManufacturerName.Length < 4 || m.ManufacturerName.Length > 40)
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if (m.Founded.Length < 10 || m.Founded.Length > 100)
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if (manufacturers.Any(x => x.ManufacturerName == m.ManufacturerName))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    manufacturers.Add(new Manufacturer()
                    {
                        ManufacturerName = m.ManufacturerName,
                        Founded = m.Founded
                    });
                    var foundedArr = m.Founded.Split(',');
                    sb.AppendLine($"Successfully import manufacturer {m.ManufacturerName} founded in {foundedArr[foundedArr.Length - 2]},{foundedArr[foundedArr.Length - 1]}.");
                }
                context.Manufacturers.AddRange(manufacturers);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }
        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();
            const string root = "Shells";
            using (StringReader str=new StringReader(xmlString))
            {
                var dtos = XmlConverter.Deserializer<ShellDto>(xmlString, root);
                ICollection<Shell> shells = new HashSet<Shell>();
                foreach (var s in dtos)
                {
                    if (IsValid(s))
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if(s.ShellWeight < 2 || s.ShellWeight > 1680)
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    if (s.Caliber.Length < 4 || s.Caliber.Length > 30)
                    {
                        sb.AppendLine("Invalid data.");
                        continue;
                    }
                    shells.Add(new Shell()
                    {
                        ShellWeight = s.ShellWeight,
                        Caliber = s.Caliber,
                    });
                    sb.AppendLine($"Successfully import shell caliber #{s.Caliber} weight {s.ShellWeight} kg.");
                }
                context.Shells.AddRange(shells);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }
        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();
            InitializeAutoMapper();
            var dtos = JsonConvert.DeserializeObject<IEnumerable<GunDto>>(jsonString);
            ICollection<Gun> guns = new HashSet<Gun>();
           foreach (var item in dtos)
            {
                if (IsValid(item))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                if (item.GunWeight < 100 || item.GunWeight > 1_350_000)
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                if (item.BarrelLength < 2.00 || item.BarrelLength > 35.00)
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                if (item.Range < 1 || item.Range > 100_000)
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                if (item.GunType != "Howitzer" || item.GunType !="Mortar" || item.GunType != "FieldGun" || item.GunType != "AntiAircraftGun" || item.GunType != "AntiTankGun " || item.GunType != "MountainGun")
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }
                guns.Add(new Gun()
                {
                    ManufacturerId = item.ManufacturerId,
                    GunWeight = item.GunWeight,
                    BarrelLength = item.BarrelLength,
                    NumberBuild = item.NumberBuild,
                    Range = item.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), item.GunType,ignoreCase : true),
                    ShellId = item.ShellId,
                    CountriesGuns = item.Countries.Select(x => x.Id),
                });
                sb.AppendLine($"Successfully import gun {item.GunType} with a total weight of {item.GunWeight} kg. and barrel length of {item.BarrelLength} m.");
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ArtilleryProfile>();
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullDestinationValues = true;
            });
            mapper = config.CreateMapper();
        }
    }
}
