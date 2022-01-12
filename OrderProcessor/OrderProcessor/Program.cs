using ProductLibrary;
using System;
using System.Collections.Generic;

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

            var productFactory = FactoryProducer.GetProductFactory(true);
            var bookProduct = productFactory.GetProduct(ProductType.Book, "Walking dead");
            
        }
    }
}
