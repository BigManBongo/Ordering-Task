using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime;
using System.Threading;
using System.Transactions;

namespace OrderingTask
{
    public class Customers
    {
        public static List<Customers> CustomerList = new List<Customers>();
        public static Customers Currentcustomer = null;

        public string Username;
        public string Password;
        public string Firstname;
        public string Lastname;
        public string Email;
        public string Address;


        public static void CustomerRegister()
        {
            Console.Write("Enter a username: ");
            string Username = Console.ReadLine();

            if (CustomerList.Exists(c => c.Username == Username))
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

            CustomerList.Add(new Customers
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

        public static void CustomerLogin()
        {
             Console.Write("Username: ");
             string Username = Console.ReadLine();

             Console.Write("Password: ");
             string Password = Console.ReadLine();

             Currentcustomer = CustomerList.Find(c => c.Username == Username && Password == Password);

             if (Currentcustomer != null)
             {
                Console.Clear();
                Console.WriteLine("Welcome back " + Currentcustomer.Username);
                Customers.CustomerMenu();
             }
             else
             {
                Console.WriteLine("Invalid username or password");
            }
        }

        public static void CustomerProfile()
        {
            Console.WriteLine("Profile:");
            Console.WriteLine("Username: " + Currentcustomer.Username);
            Console.WriteLine("First Name: " + Currentcustomer.Firstname);
            Console.WriteLine("Last Name: " + Currentcustomer.Lastname);
            Console.WriteLine("Email: " + Currentcustomer.Email);
            Console.WriteLine("Address: " + Currentcustomer.Address);
        }
        public static void CustomerMenu()
        {
            int CustomerInput = 0;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. View Profile");
            Console.WriteLine("3. Logout");
            Console.Write("\r\nSelect an option: ");
            CustomerInput = Convert.ToInt32(Console.ReadLine());
            do
            {
                switch (CustomerInput)
                {
                    case 1:
                        MenuItems.ViewMenu();
                        break;
                    case 2:
                        Customers.CustomerProfile();
                        break;
                    case 3:
                        Customers Currentcustomer = null;
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT!");
                        break;
                }
            } while (CustomerInput != 4);
        }
        
    }
}