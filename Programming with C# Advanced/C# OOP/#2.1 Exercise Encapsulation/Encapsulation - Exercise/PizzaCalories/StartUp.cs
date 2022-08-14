using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];
                string doughFlourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double doughWight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlourType, bakingTechnique, doughWight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingType = Console.ReadLine().Split();
                while (toppingType[0] != "END")
                {
                    string type = toppingType[1];
                    double weight = double.Parse(toppingType[2]);
                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingType = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
