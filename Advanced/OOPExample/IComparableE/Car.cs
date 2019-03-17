using System;
using System.Collections;

namespace OOPExample.IComparableE
{
    internal class Car : IComparable
    {
        public string Name { get; set; }
        public int CurrentSpeed { get; set; }
        public int CarID { get; set; }

        public Car()
        {
        }

        public Car(string name, int currentSpeed)
            : this(name, currentSpeed, 0) { }

        public Car(string name)
            : this(name, 0, 0) { }

        public Car(string name, int currentSpeed, int id)
        {
            Name = name;
            CurrentSpeed = currentSpeed;
            CarID = id;
        }

        // IComparable implementation.
        int IComparable.CompareTo(object obj)
        {
            Car temp = obj as Car;

            // We using the CarID as the base for the sort order.
            if (temp != null)
                return this.CarID.CompareTo(temp.CarID);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }

        public static IComparer SortByName
        {
            get { return (IComparer)new NameComparer(); }
        }
    }

    public class NameComparer : IComparer
    {
        int IComparer.Compare(object o1, object o2)
        {
            Car t1 = o1 as Car;
            Car t2 = o2 as Car;

            if (t1 != null && t2 != null)
            {
                return String.Compare(t1.Name, t2.Name);
            }
            else
            {
                throw new ArgumentException("Parameter is not a Car");
            }
        }
    }

    public static class CarIcomparableTest
    {
        // Test the IComparable Interface for sorting of an array
        public static void CarIcomparableInterface()
        {
            Car[] carAutos = new Car[5];

            carAutos[0] = new Car("Rusty", 90, 1);
            carAutos[1] = new Car("Mary", 40, 234);
            carAutos[2] = new Car("Viper", 40, 34);
            carAutos[3] = new Car("Mel", 40, 3);
            carAutos[4] = new Car("Chucky", 40, 5);

            // Display Current array
            Console.WriteLine("Here is the unordered set of cars:");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }

            // Now, sort them using IComparable
            Array.Sort(carAutos);
            Console.WriteLine();

            // Display sorted array.
            Console.WriteLine("Here is the ordered set of cars:");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }
        }

        public static void CarIcomparerTest()
        {
            Car[] carAutos = new Car[5];

            carAutos[0] = new Car("Rusty", 90, 1);
            carAutos[1] = new Car("Mary", 40, 234);
            carAutos[2] = new Car("Viper", 40, 34);
            carAutos[3] = new Car("Mel", 40, 3);
            carAutos[4] = new Car("Chucky", 40, 5);

            // Before sorting
            Console.WriteLine("***** Before sorting *****");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }

            // Sort by Name.
            Array.Sort(carAutos, new NameComparer());
            Console.WriteLine();

            // Dump sorted array.
            Console.WriteLine("***** Ordering by Name *****");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }
        }

        public static void SortByNameProperies()
        {
            Car[] carAutos = new Car[5];

            carAutos[0] = new Car("Rusty", 90, 1);
            carAutos[1] = new Car("Mary", 40, 234);
            carAutos[2] = new Car("Viper", 40, 34);
            carAutos[3] = new Car("Mel", 40, 3);
            carAutos[4] = new Car("Chucky", 40, 5);

            // Before sorting
            Console.WriteLine("***** Before sorting *****");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }

            // Sort by Name.
            // This implementation is more clear than before
            Array.Sort(carAutos, Car.SortByName);
            Console.WriteLine();

            // Dump sorted array.
            Console.WriteLine("***** Ordering by Name *****");
            foreach (Car car in carAutos)
            {
                Console.WriteLine("{0} {1}", car.CarID, car.Name);
            }
        }
    }
}