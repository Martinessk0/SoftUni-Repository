using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendaryItem = new Dictionary<string, int>();
            legendaryItem.Add("shards", 0);
            legendaryItem.Add("fragments", 0);
            legendaryItem.Add("motes", 0);
            var junkMaterials = new Dictionary<string, int>();
            bool isLegendaryFound = false;
            while (!isLegendaryFound)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 1; i < input.Length; i += 2)
                {
                    string keyMaterial = input[i].ToLower();
                    int valueMaterial = int.Parse(input[i - 1]);
                    if (keyMaterial == "shards" || keyMaterial == "fragments" || keyMaterial == "motes")
                    {
                        legendaryItem[keyMaterial] += valueMaterial;
                        if (legendaryItem[keyMaterial] >= 250)
                        {
                            isLegendaryFound = true;
                            break;
                        }
                    }
                    else if (junkMaterials.ContainsKey(keyMaterial))
                    {
                        junkMaterials[keyMaterial] += valueMaterial;
                    }
                    else
                    {
                        junkMaterials.Add(keyMaterial,valueMaterial);
                    }
                }
            }

            if (legendaryItem["shards"] >=250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                legendaryItem["shards"] -= 250;
            }
            else if (legendaryItem["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                legendaryItem["fragments"] -= 250;
            }
            else if (legendaryItem["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                legendaryItem["motes"] -= 250;
            }
            foreach (var item in legendaryItem.OrderByDescending(key => key.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var material in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
