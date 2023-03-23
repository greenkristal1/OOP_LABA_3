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
    class Storage
    {
        private Base[] arr;
        private int size;

        public Storage(int size)
        {

            arr = new Base[size];
            this.size = size;
        }
        ~Storage()
        {

        }
        public int getCount()
        {
            return size;
        }
        public void setObject(int index, Base o)
        {
            if (index < size && index >= 0 && arr[index] == null)
                arr[index] = o;
            else if (index >= 0)
            {

                Base[] temp = new Base[size + 1];
                for (int i = 0; i < size; i++)
                {
                    temp[i] = arr[i];

                }
                temp[size] = o;
                size++;
                arr = temp;

            }
        }
        public Base getObject(int index)
        {

            return arr[index];

        }

        public void deleteObject(int index)
        {
            if (index < size)
            {
                Base[] temp = new Base[size - 1];
                for (int i = 0; i < index; i++)
                {
                    temp[i] = arr[i];
                }
                size--;
                for (int i = index; i < size; i++)
                {
                    temp[i] = arr[i + 1];
                }

                arr = temp;
            }
        }
    }


        class Program
    {

    }
}
