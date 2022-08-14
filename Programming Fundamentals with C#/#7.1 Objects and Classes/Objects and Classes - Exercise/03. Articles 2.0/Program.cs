using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 1; i <= n; i++)
            {
                string[] cmd = Console.ReadLine().Split(", ");
                string title = cmd[0];
                string content = cmd[1];
                string author = cmd[2];
                Article article = new Article()
                {
                    Author = author,
                    Content = content,
                    Title = title
                };
                articles.Add(article);
            }
            string sort = Console.ReadLine();
            switch (sort)
            {
                case "author":
                    foreach (var article in articles.OrderBy(x => x.Author))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
                case "title":
                    foreach (var article in articles.OrderBy(x => x.Title))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
                case "content":
                    foreach (var article in articles.OrderBy(x => x.Content))
                    {
                        Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                    }
                    break;
            }
        }
    }
}
