using System;
using System.Collections.Generic;
namespace inventory
{
    public class Program
    {
        public static void Main()
        {
            Inventory inventory = new Inventory();
            inventory.AddProduct("Watermelon", 50);
            inventory.AddProduct("Apple", 30);

            Console.WriteLine($"Quantity of Watermelon: {inventory.GetQuantityByProduct("Watermelon")}");

            inventory.UpdateQuantity("Watermelon", 60);
            Console.WriteLine($"Updated quantity of Watermelon: {inventory.GetQuantityByProduct("Watermelon")}");

            inventory.RemoveProduct("Apple");
            Console.WriteLine($"Quantity of Apple: {inventory.GetQuantityByProduct("Apple")}");
        }
    }
}