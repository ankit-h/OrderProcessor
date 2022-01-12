﻿using System;
using System.Collections.Generic;

namespace ProductLibrary
{
    public abstract class Product
    {
        public List<string> Actions { get; set; }
        public string Name { get; set; }
        public virtual void GetSlip()
        {
            Actions.Add("Packaging Slip");
        }

        public virtual void AddCommision()
        {
            Actions.Add("Generated commision to the agent");
        }

        public virtual void SendMail()
        {
            Actions.Add("Sent email to owner for membership activation/upgrade");
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
       
        public override void GetSlip()
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

        public override void GetSlip()
        {
            base.GetSlip();
            if (this.Name == "Learning to Ski")
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
    {        public Upgrade(string name)
        {
            this.Name = name;
            Actions.Add("Upgrade Membership");
            SendMail();
        }
    }

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
        Book,
        Video,
        Membership,
        Upgrade
    }

}