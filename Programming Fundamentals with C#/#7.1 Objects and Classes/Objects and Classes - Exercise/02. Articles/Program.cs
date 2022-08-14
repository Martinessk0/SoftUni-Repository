using System;

namespace _02._Articles
{
    class Program
    {
        class Article
        {
            private string title_;
            private string content_;
            private string author_;

            public Article(string title, string content, string author)
            {
                Author = author;
                Title = title;
                Content = content;
            }

            public string Title
            {
                get => title_;
                set => title_ = value;
            }
            public string Content
            {
                get => content_;
                set => content_ = value;
            }
            public string Author
            {
                get => author_;
                set => author_ = value;
            }
            public void Edit(string content)
            {
                Content = content;
            }
            public void ChangeAuthor(string author)
            {
                Author = author;
            }
            public void Rename(string title)
            {
                Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());
            Article article = new Article(input[0],input[1],input[2]);
            for (int i = 1; i <= n; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");
                string action = cmd[0];
                string command = cmd[1];

                switch (action)
                {
                    case "Edit":
                        article.Edit(command);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command);
                        break;
                    case "Rename":
                        article.Rename(command);
                        break;
                }
            }
            Console.WriteLine(article);
        }
    }
}
