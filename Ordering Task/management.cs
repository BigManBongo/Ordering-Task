using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime;
using System.Threading;
using System.Transactions;

namespace OrderingTask
{
    public class Management
    {
        public static List<Management> ManagementList = new List<Management>();
        public static Management Currentmanager = null;

        public string Username;
        public string Password;
        public string Firstname;
        public string Lastname;
        public string Email;
        public string Address;

        static int lastId = 0;

        public static int GenerateID()
        {
            return Interlocked.Increment(ref lastId);
        }

        public static void ManagementRegister()
        {
            Console.Write("Enter a username: ");
            string Username = Console.ReadLine();

            if (ManagementList.Exists(c => c.Username == Username))
            {
                Console.WriteLine("Username is already taken. Please enter a different username:");
                return;
            }

            Console.Write("Enter a secure password: ");
            string Password = Console.ReadLine();

            Console.Write("Enter your first name: ");
            string Firstname = Console.ReadLine();

            Console.Write("Enter your last name: ");
            string Lastname = Console.ReadLine();

            Console.Write("Enter your email address: ");
            string Email = Console.ReadLine();

            Console.Write("Enter your address: ");
            string Address = Console.ReadLine();

            int CustomerID = GenerateID();

            ManagementList.Add(new Management
            {
                Username = Username,
                Password = Password,
                Firstname = Firstname,
                Lastname = Lastname,
                Email = Email,
                Address = Address
            });

            Console.WriteLine("You are now registered.");
        }

        public static void ManagementLogin()
        {
            Console.Write("Username: ");
            string Username = Console.ReadLine();

            Console.Write("Password: ");
            string Password = Console.ReadLine();

            Currentmanager = ManagementList.Find(c => c.Username == Username && Password == Password);

            if (Currentmanager != null)
            {
                Console.Clear();
                Console.WriteLine("Welcome back " + Currentmanager.Username);
                Management.ManagementMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password");
            }
        }

        public static void ManagementProfile()
        {
            Console.WriteLine("Profile:");
            Console.WriteLine("Username: " + Currentmanager.Username);
            Console.WriteLine("First Name: " + Currentmanager.Firstname);
            Console.WriteLine("Last Name: " + Currentmanager.Lastname);
            Console.WriteLine("Email: " + Currentmanager.Email);
            Console.WriteLine("Address: " + Currentmanager.Address);
        }
        public static void ManagementMenu()
        {
            int ManagerInput = 0;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add an item to the menu");
            Console.WriteLine("2. Update an existing item on the menu");
            Console.WriteLine("3. Remove an item from the menu");
            Console.WriteLine("4. View Profile");
            Console.WriteLine("5. Logout");
            Console.Write("\r\nSelect an option: ");
            ManagerInput = Convert.ToInt32(Console.ReadLine());
            do
            {
                switch (ManagerInput)
                {
                    case 1:
                        MenuItems.AddItem();
                        break;
                    case 2:
                        MenuItems.UpdateItem();
                        break;
                    case 3:
                        MenuItems.RemoveItem();
                        break;
                    case 4:
                        Management.ManagementProfile();
                        break;
                    case 5:
                        Customers Currentcustomer = null;
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT!");
                        break;
                }
            } while (ManagerInput != 6);
        }
        
    }
}
