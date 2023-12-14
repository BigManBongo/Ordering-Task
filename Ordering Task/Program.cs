using OrderingTask;
using System;
using System.Collections.Generic;

namespace OrderingTask
{
    public class Mainmenu
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Register Customer Account");
            Console.WriteLine("2. Customer Login");
            Console.WriteLine("3. Register Management Account");
            Console.WriteLine("4. Management Login");
            Console.WriteLine("5. Close Program");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Customers.CustomerRegister();
                    return true;
                case "2":
                    Customers.CustomerLogin();
                    return true;
                case "3":
                    Management.ManagementRegister();
                    return true;
                case "4":
                    Management.ManagementLogin();
                    return false;
                case "5":

                    return false;
                default:
                    Console.WriteLine("INVALID INPUT!");
                    return true;
            }
        }

    }
}