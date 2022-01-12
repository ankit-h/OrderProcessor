using ProductLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrderProcessor
{
    /*
    public abstract class Product
    {
        public List<string> Actions { get; set; }
        public string Name { get; set; }
        public abstract void GetSlip();

    }

    public abstract class PhysicalProduct : Product
    {
        public PhysicalProduct()
        {
            Actions = new List<string>();          
        }
        public override void GetSlip()
        {
            Actions.Add("Packaging Slip");
        }

        public virtual void GenerateCommision()
        {
            Actions.Add("Generated commision to the agent");
        }
    }

    public abstract class NonPhysicalProduct : Product
    {
        public NonPhysicalProduct()
        {
            Actions = new List<string>();
        }
        public override void GetSlip()
        {
            Actions.Add("Packaging Slip");
        }

        public void SendEmail()
        {
            Actions.Add("Sent email to owner for membership activation/upgrade");
        }

    }

    public class Book : PhysicalProduct
    {
        public Book(string name)
        {
            this.Name = name;
            base.GetSlip();
            GetSlip();
            base.GenerateCommision();           
          
        }
        public new void GetSlip()
        {            
            Actions.Add("duplicate slip for royalty department");
        }
    }

    public class Membership : NonPhysicalProduct
    {
        public Membership(string name)
        {
            this.Name = name;
            Actions.Add("Activate Membership");
            SendEmail();
        }       
    }

    public class Upgrade : NonPhysicalProduct
    {
        public Upgrade(string name)
        {
            this.Name = name;
            Actions.Add("Upgrade Membership");
            SendEmail();
        }
    }

    public class Video : NonPhysicalProduct
    {
        public Video(string name)
        {
            this.Name = name;
            GetSlip();
        }

        public override void GetSlip()
        {
            base.GetSlip();
            if (this.Name == "Learning to Ski")
            {
                Actions.Add("Added Free First Aid Video");
            }
        }
    }
    */

   
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
