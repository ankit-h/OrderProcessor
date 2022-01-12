using System;

namespace OrderProcessor
{
    public abstract class Product
    {

    }

    public abstract class PhysicalProduct : Product
    {

    }

    public abstract class NonPhysicalProduct : Product
    {

    }

    public class Book : PhysicalProduct
    {

    }

    public class Membership : NonPhysicalProduct
    {

    }

    public class Upgrade : NonPhysicalProduct
    {

    }

    public class Video : NonPhysicalProduct
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
