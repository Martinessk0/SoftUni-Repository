using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();
                string[] peopleInput = Console.ReadLine().Split(';');
                foreach (var persons in peopleInput)
                {
                    string[] personInfo = persons.Split('=');
                    Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                    people.Add(person);

                }
                string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var productss in productInput)
                {
                    string[] productInfo = productss.Split('=');
                    Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(product);
                }

                string[] command = Console.ReadLine().Split(' ');
                while (command[0] != "END")
                {
                    string nameInfo = command[0];
                    string productInfo = command[1];
                    Person person = people.First(x => x.Name == nameInfo);
                    Product product = products.First(x => x.Name == productInfo);
                    person.BuyProduct(product);

                    command = Console.ReadLine().Split(' ');
                }
                foreach (var person in people)
                {
                    if (person.Bag.Count > 0)
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

            }
        }
    }
}
