using System;
using System.Collections.Generic;
using System.Net;

namespace OrderingTask
{
    public class MenuItems
    {
        public static List<MenuItems> ItemList = new List<MenuItems>();
        public static MenuItems ItemToRemove = null;

        public string Name;
        public string Description;
        public decimal Price;
        public string Category;

        public static void ViewMenu()
        {
            Console.WriteLine("");
        }

        public static void AddItem()
        {
            Console.Write("Enter the item's name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter the item's description: ");
            string Description = Console.ReadLine();

            Console.Write("Enter the item's price: ");
            decimal Price = decimal.Parse(Console.ReadLine());
            
            Console.Write("Enter the category of the item (Appetiser, Main Course or Dessert: ");
            string Category = Console.ReadLine();

            ItemList.Add(new MenuItems
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Category = Category,

            });
        }

        public static void UpdateItem()
        {

        }

        public static void RemoveItem()
        {
            Console.Write("Enter the name of the item you wish to remove: ");
            string RemovalInput = Console.ReadLine();

            MenuItems ItemToRemove = ItemList.Find(i => i.Name == RemovalInput);

            if (RemovalInput != null)
            {
                ItemList.Remove(ItemToRemove);
                Console.WriteLine("The chosen item has been removed");
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }
    }
}
