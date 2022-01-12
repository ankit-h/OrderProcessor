using ProductLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProcessor
{   
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Create a physical product? (y - physical) : ");
            var isPhysical = Convert.ToBoolean(Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase));
            
            foreach (var item in Enum.GetValues(typeof(ProductType)))
            {
                var fieldInfo = item.GetType().GetField(item.ToString());

                var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (descriptionAttributes[0].Description.Equals(isPhysical ? "physical" : "non-physical", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.Write("Enter the supported product type :");
            var typeName = Console.ReadLine();
            if (Enum.TryParse<ProductType>(typeName, true, out ProductType type))
            {
                Console.Write("Enter Name of the product to create: ");
                var productName = Console.ReadLine();
                var product = GetProduct(isPhysical, type, productName);
                Console.WriteLine("List of Actions are as follows: ");
                product.GetActions();
            }
            else
            {
                Console.WriteLine("Invalid product entered");
            }
        }

        public static Product GetProduct(bool isPhysicalProduct, ProductType type, string productName)
        {
            var productFactory = FactoryProducer.GetProductFactory(isPhysicalProduct);
            return productFactory.GetProduct(type, productName);
        }
    }
}
