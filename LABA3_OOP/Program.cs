using System;
using System.Diagnostics;
//with, sealed ключевое слово
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
        public int countRealObjects()
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] != null)
                    count++;
            }
            return count;
        }
        public Base takeOutObject(int index)
        {

            if (index < size)
            {
                Base o = arr[index];
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
                return o;
            }
            else return null;

        }
    }


    class Program
    {


        static void storage_test(int num_actioons)
        {
            Random rnd = new Random();
            Storage st = new Storage(num_actioons);
            for (int i = 0; i < st.getCount(); i++)
            {
                int a = rnd.Next(1, 3);
                switch (a)
                {
                    case 1:
                        st.setObject(i, new Circle());
                        break;
                    case 2:
                        st.setObject(i, new Car());
                        break;
                }

            }
            for (int i = 0; i < st.getCount(); i++)
            {
                Console.WriteLine(st.getObject(i));
            }
            for (int i = 0; i < st.getCount(); i++)
            {
                int index = rnd.Next(0, st.getCount());
                int action = rnd.Next(1, 6);
                switch (action)
                {
                    case 1:
                        if (st.getObject(index) != null)
                        {
                            Console.WriteLine("Вызов getObject");
                            st.getObject(index).printName();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Вызов setObject");
                        int a = rnd.Next(1, 3);
                        switch (a)
                        {
                            case 1:
                                st.setObject(st.getCount(), new Circle());
                                break;
                            case 2:
                                st.setObject(st.getCount(), new Car());
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Вызов delete Object");
                        st.deleteObject(index);
                        break;
                    case 4:
                        Console.WriteLine("Вызов  count_real_objects");
                        st.countRealObjects();
                        break;
                    case 5:
                        Console.WriteLine("Вызов  takeObject");
                        st.takeOutObject(index);
                        break;

                }
            }

        }

        static void Main(string[] args)
        {
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();
            sw1.Start();
            storage_test(100);
            sw1.Stop();

            sw2.Start();
            storage_test(1000);
            sw2.Stop();

            sw3.Start();
            storage_test(10000);
            sw3.Stop();



            Console.WriteLine("Время для 100 операций: " + sw1.Elapsed);
            Console.WriteLine("Время для 1000 операций: " + sw2.Elapsed);
            Console.WriteLine("Время для 10000 операций: " + sw3.Elapsed);
        }
    }
}

}
