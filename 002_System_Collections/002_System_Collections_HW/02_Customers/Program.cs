/*
 * Створіть колекцію, до якої можна додавати покупців та категорію придбаної ними продукції. 
 * З колекції можна отримувати категорії товарів, 
 * які купив покупець або за категорією визначити покупців.
 */

using System.Collections.Specialized;

namespace Customers
{
    internal class Program
    {
        static StringCollection GetCategoriesByCustomer(NameValueCollection collection, string customer)
        {
            StringCollection categories = new StringCollection();
            foreach (string s in collection.GetValues(customer))
            {
                categories.Add(s);
            }
            return categories;
        }

        //static StringCollection GetCustomersByCategory(NameValueCollection collection, string category)
        //{
        //    StringCollection customers = new StringCollection();
        //    foreach (var item in collection)
        //    {
        //        if (collection.GetValues(item.))
        //        {

        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            var customers = new NameValueCollection();

            customers.Add("John Smith", "Food");
            customers.Add("Michael Gordon", "Furniture");
            customers.Add("John Smith", "Clothes");
            customers.Add("Jane Doe", "Food");

            string customer = "John Smith1";
            Console.WriteLine($"List of goods categories of {customer}:");
            if (customers[customer] != null)
            {
                try
                {
                    foreach (var item in GetCategoriesByCustomer(customers, customer))
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
            else
            {
                Console.WriteLine($"The customer {customer} is not in the list");
            }

                // Delay.
                Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
