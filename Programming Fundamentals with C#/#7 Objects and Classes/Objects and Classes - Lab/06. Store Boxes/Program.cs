using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace _06._Store_Boxes
{
    class Program
    {
        class Item
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        class Box
        {
            public Box()
            {
                Item = new Item();
            }
            public long SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public decimal PricePerBox { get; set; }
        }
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            //List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();
            while (command[0] != "end")
            {
                long serialNumber = long.Parse(command[0]);
                string itemName = command[1];
                int itemQuantity = int.Parse(command[2]);
                decimal itemPrice = decimal.Parse(command[3]);
                Item Item = new Item();
                Item.Name = itemName;
                Item.Price = itemPrice;
                Box Box = new Box();
                Box.Item = Item;
                Box.SerialNumber = serialNumber;
                Box.ItemQuantity = itemQuantity;
                Box.PricePerBox = itemQuantity * itemPrice;

                boxes.Add(Box);
                command = Console.ReadLine().Split();
            }
            foreach (var box in boxes.OrderByDescending(bp => bp.PricePerBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PricePerBox:F2}");

            }
        }
    }
}
