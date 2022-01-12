using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProductLibrary
{
    #region concrete products
    public abstract class Product
    {
        public Product()
        {
            Actions = new List<string>();
        }
        internal List<string> Actions { get; set; }
        public string Name { get; internal set; }
        public int ActionCount { get { return Actions.Count; } }
        internal virtual void GetSlip()
        {
            Actions.Add("Packaging Slip");
        }

        internal virtual void AddCommision()
        {
            Actions.Add("Generated commision to the agent");
        }

        internal virtual void SendMail()
        {
            Actions.Add("Sent email to owner for membership activation/upgrade");
        }

        public void GetActions()
        {
            for (int i = 1; i <= Actions.Count; i++)
            {
                Console.WriteLine($"{i}. {Actions[i - 1]}");
            }
        }
    }

    internal class Book : Product
    {
        public Book(string name)
        {
            this.Name = name;
            GetSlip();
            AddCommision();
        }

        internal override void GetSlip()
        {
            base.GetSlip();
            Actions.Add("duplicate slip for royalty department");
        }

    }

    internal class Video : Product
    {
        public Video(string name)
        {
            this.Name = name;
            GetSlip();
        }

        internal override void GetSlip()
        {
            base.GetSlip();
            if (this.Name.Equals("Learning to Ski", StringComparison.InvariantCultureIgnoreCase))
            {
                Actions.Add("Added Free First Aid Video");
            }
        }
    }

    internal class Membership : Product
    {
        public Membership(string name)
        {
            this.Name = name;
            Actions.Add("Activate Membership");
            SendMail();
        }
    }

    internal class Upgrade : Product
    {
        public Upgrade(string name)
        {
            this.Name = name;
            Actions.Add("Upgrade Membership");
            SendMail();
        }
    }

    #endregion



    #region producer factories

    public abstract class ProductFactoryProducer
    {
        public abstract Product GetProduct(ProductType type, string productName);
    }

    public class PhysicalProductFactory : ProductFactoryProducer
    {
        public override Product GetProduct(ProductType type, string productName)
        {
            switch (type)
            {

                case ProductType.Book:
                    return new Book(productName);
                case ProductType.Video:
                case ProductType.Membership:
                case ProductType.Upgrade:
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class NonPhysicalProductFactory : ProductFactoryProducer
    {
        public override Product GetProduct(ProductType type, string productName)
        {
            switch (type)
            {
                case ProductType.Video:
                    return new Video(productName);

                case ProductType.Membership:
                    return new Membership(productName);

                case ProductType.Upgrade:
                    return new Upgrade(productName);

                case ProductType.Book:
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class FactoryProducer
    {
        public static ProductFactoryProducer GetProductFactory(bool isPhysicalProduct)
        {
            return isPhysicalProduct ? ((ProductFactoryProducer)new PhysicalProductFactory()) : ((ProductFactoryProducer)new NonPhysicalProductFactory());
        }
    }

    public enum ProductType
    {
        [Description("Physical")]
        Book,

        [Description("Non-Physical")]
        Video,

        [Description("Non-Physical")]
        Membership,

        [Description("Non-Physical")]
        Upgrade
    }

    #endregion

}
