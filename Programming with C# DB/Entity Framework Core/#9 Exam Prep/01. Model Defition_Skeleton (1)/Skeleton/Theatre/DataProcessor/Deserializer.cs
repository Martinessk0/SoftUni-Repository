namespace Theatre.DataProcessor
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using Theatre.XmlHelper;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        static IMapper mapper;
        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            const string root = "Plays";
            InitializeAutoMapper();
            var dtos = XmlConverter.Deserializer<PlayExportDto>(xmlString, root);
            ICollection<Play> plays = new List<Play>();

            foreach (var curr in dtos)
            {                  
                if (curr.Title.Length < 4 || curr.Title.Length > 50)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (curr.Duration.TotalSeconds < 3600 )
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (curr.Genre.ToString() != "Drama" || curr.Genre.ToString() != "Comedy" || curr.Genre.ToString() != "Romance" || curr.Genre.ToString() != "Musical")
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (curr.Rating < 0 || curr.Rating > 10)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (curr.Description.Length > 700)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                if (curr.Screenwriter.Length < 4 || curr.Screenwriter.Length > 50)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Play play = new Play()
                {
                    Title = curr.Title,
                    Duration = curr.Duration,
                    Genre = Enum.Parse<Genre>(curr.Genre),
                    Rating = curr.Rating,
                    Description = curr.Description,
                    Screenwriter = curr.Screenwriter,
                };
                plays.Add(play);
                sb.AppendLine($"Successfully imported {curr.Title} with genre {curr.Genre} and a rating of {curr.Rating}!");
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            throw new NotImplementedException();
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
                cfg.AddProfile<TheatreProfile>();
            });
            mapper = config.CreateMapper();
        }
    }
}
