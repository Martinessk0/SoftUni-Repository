namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using BookShop.DataProcessor.XmlHelper;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            const string root = "Books";
            var sb = new StringBuilder();
            var booksDto = XmlConverter.Deserializer<BookImportModelDto>(xmlString, root);
            var books= new List<Book>();
            foreach (var book in booksDto)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                var isPublishedOnValid=DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None,out publishedOn);
                if (!isPublishedOnValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var b = new Book()
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = publishedOn,
                };
                books.Add(b);
                sb.AppendLine($"Successfully imported book {b.Name} for {b.Price:f2}.");
            }
            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var authorsDto = JsonConvert.DeserializeObject<AuthorImportModelDto[]>(jsonString);
            var books = context.Books.ToList();
            var authors = new List<Author>();
            foreach (var author in authorsDto)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (authors.Any(x => x.Email == author.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var a = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email,
                };
                foreach (var book in author.Books)
                {
                    var b = books.Find(x => x.Id == book.Id);

                    if (b == null)
                    {
                        continue;
                    }

                    a.AuthorsBooks.Add(new AuthorBook()
                    {
                        Book = b
                    });
                }
                if (a.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                authors.Add(a);
                sb.AppendLine($"Successfully imported author - {a.FirstName} {a.LastName} with {a.AuthorsBooks.Count} books.");
            }
            context.Authors.AddRange(authors);
            context.SaveChanges();
           
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}