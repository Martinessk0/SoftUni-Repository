namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using BookShop.DataProcessor.XmlHelper;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books=a.AuthorsBooks
                    .OrderByDescending(a => a.Book.Price)
                    .Select(ab => new
                    {
                        BookName=ab.Book.Name,
                        BookPrice=ab.Book.Price.ToString(),
                    })
                })
                .OrderByDescending(a => a.Books.Count())
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var jsonResult=JsonConvert.SerializeObject(authors,Formatting.Indented);
            return jsonResult;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            const string root = "Books";
            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre.ToString() == "Science")
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Select(b => new BookExportModelDto()
                {
                    Name = b.Name,
                    Pages = b.Pages.ToString(),
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .Take(10)
                .ToArray();
            var xmlResult = XmlConverter.Serialize(books, root);
            return xmlResult;
        }
    }
}