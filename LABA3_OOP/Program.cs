using System;

namespace LABA3_OOP
{

    abstract class Base
    {
        public abstract string Name { get; init; }
        public abstract void printName();

        ~Base()
        {

        }
    }


    class Circle : Base
    {

        public override string Name { get; init; } = "Circle";
        public int Radius { get; private set; }
        public Circle()
        {
            Radius = 1;

        }
        public Circle(int length)
        {
            Radius = length;

        }
        public Circle(Circle c)
        {
            Console.WriteLine("Copy constructor");
            this.Radius = c.Radius;
        }
        public override void printName()
        {
            Console.WriteLine($"The name of this object is {Name}");
        }


    }
    class Car : Base
    {
        public override string Name { get; init; } = "Car";
        public string Brand { get; private set; }
        public Car()
        {
            Brand = "Toyota";
        }

        public Car(string brand)
        {
            Brand = brand;
        }
        public override void printName()
        {
            Console.WriteLine($"This is the object {Name}, brand is {Brand}");
        }
    }


    class Program
    {

    }
}
