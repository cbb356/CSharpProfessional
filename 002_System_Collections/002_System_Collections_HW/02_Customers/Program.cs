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
            var categories = new StringCollection();

            var values = collection.GetValues(customer);
            if (values == null)
                return categories;

            foreach (var v in values)
            {
                if (!string.IsNullOrEmpty(v))
                    categories.Add(v);
            }

            return categories;
        }

        static StringCollection GetCustomersByCategory(NameValueCollection collection, string category)
        {
            var customers = new StringCollection();
            if (string.IsNullOrEmpty(category))
                return customers;

            var keys = collection.AllKeys;
            if (keys == null)
                return customers;

            foreach (var key in keys)
            {
                var values = collection.GetValues(key);
                if (values == null)
                    continue;

                foreach (var v in values)
                {
                    if (string.Equals(v, category, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!customers.Contains(key))
                            customers.Add(key);
                        break; // no need to check other values for this key
                    }
                }
            }

            return customers;
        }

        static void Main(string[] args)
        {
            var customers = new NameValueCollection();

            customers.Add("John Smith", "Food");
            customers.Add("Michael Gordon", "Furniture");
            customers.Add("John Smith", "Clothes");
            customers.Add("Jane Doe", "Food");
            customers.Add("Alex Roe", "Food");
            customers.Add("Alex Roe", "Electronics");

            // Example: categories for a given customer
            string customer = "John Smith";
            Console.WriteLine($"List of goods categories for {customer}:");
            var categories = GetCategoriesByCustomer(customers, customer);
            if (categories.Count > 0)
            {
                foreach (var item in categories)
                    Console.WriteLine(item);
            }
            else
            {
                Console.WriteLine($"The customer {customer} is not in the list or has no categories.");
            }

            Console.WriteLine();

            // Example: customers for a given category
            string category = "Food";
            Console.WriteLine($"List of customers who bought category \"{category}\":");
            var buyers = GetCustomersByCategory(customers, category);
            if (buyers.Count > 0)
            {
                foreach (var c in buyers)
                    Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine($"No customers found for category '{category}'.");
            }

            // Delay.
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
