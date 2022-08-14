using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db,command));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //var year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db,year));
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db,input));
            //var date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db,date));
            //var input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db,input));
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db,input));
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db,input));
            //var input = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db,input));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            RemoveBooks(db);
        }

        //var sb = new StringBuilder();
        //return sb.ToString().TrimEnd();
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();
            return string.Join(Environment.NewLine,books);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookEdition = Enum.Parse<EditionType>("Gold", true);
            var books = context.Books
                .Where(b => b.EditionType == bookEdition && b.Copies <= 5000)
                .OrderBy(x =>x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();
            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(b => b.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price,
                    Edition = x.EditionType,
                    ReleaseDate = x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName=$"{a.FirstName} {a.LastName}",
                })
                .ToList();

            foreach (var author in authors.OrderBy(a => a.FullName))
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books.OrderBy(b => b))
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();
            var books = context.Books
                .Include(x => x.Author)
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    Title = x.Title,
                    Author = $"{x.Author.FirstName} {x.Author.LastName}",
                    Id = x.BookId
                })
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();
            var bookCopies = context.Authors
                .Select(x => new
                {
                    FullName = $"{x.FirstName} {x.LastName}",
                    Sum = x.Books.Sum(x => x.Copies),
                })
                .OrderByDescending(x => x.Sum)
                .ToList();

            foreach (var bookCopy in bookCopies)
            {
                sb.AppendLine($"{bookCopy.FullName} - {bookCopy.Sum}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();
            var category = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies),
                })
                .OrderByDescending(x => x.Profit)
                .ToList();
            foreach (var cat in category)
            {
                sb.AppendLine($"{cat.Name} ${cat.Profit:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks
                        .Select(x => new
                        {
                            ReleaseDate = x.Book.ReleaseDate,
                            BookTitle = x.Book.Title,
                        })
                        .OrderByDescending(x => x.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)    
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count();
        }
    }
}
