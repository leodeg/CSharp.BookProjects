using System;

namespace CustomGenericCollections
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UsePointGeneric();
        }

        // -------------------------------------------------------------------

        public static class MyGenericMethods
        {
            // This method will swap any two items.
            // as specified by the type parameter <T>
            public static void Swap<T>(ref T a, ref T b)
            {
                Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
                T temp = a;
                a = b;
                b = temp;
            }

            public static void DisplayBaseClass<T>()
            {
                Console.WriteLine("Base class of {0} is: {1}", typeof(T), typeof(T).BaseType);
            }
        }

        public static class TestMyGeneticMethods
        {
            public static void UseGenericSwapWithPerson()
            {
                Person personOne = new Person("John", "Black", 49);
                Person personTwo = new Person("Rosy", "Black", 38);

                Console.WriteLine("person one: {0}", personOne);
                Console.WriteLine("person two: {0}", personTwo);

                MyGenericMethods.Swap<Person>(ref personOne, ref personTwo);

                Console.WriteLine("person one: {0}", personOne);
                Console.WriteLine("person two: {0}", personTwo);
            }

            // -------------------------------------------------------------------

            public static void UseDisplayBaseClass()
            {
                MyGenericMethods.DisplayBaseClass<Person>();
                MyGenericMethods.DisplayBaseClass<string>();
                MyGenericMethods.DisplayBaseClass<int>();
                MyGenericMethods.DisplayBaseClass<float>();
                MyGenericMethods.DisplayBaseClass<double>();
                MyGenericMethods.DisplayBaseClass<char>();
                // this do not have a parent, this is a parent!
                MyGenericMethods.DisplayBaseClass<object>();
            }
        }

        /// <summary>
        /// A generic Point structure
        /// </summary>
        public struct Point<T>
        {
            private T xPos;
            private T yPos;

            // Generic Constructor
            public Point(T x, T y)
            {
                xPos = x;
                yPos = y;
            }

            // Generic Properties
            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }

            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }

            public override string ToString()
            {
                return $"[{xPos}, {yPos}]";
            }

            // Reset fields to the default value of the type parameter.
            public void ResetPoint()
            {
                xPos = default(T);
                yPos = default(T);
            }
        }

        public static void UsePointGeneric()
        {
            Console.WriteLine("**** Fun With Generic Point ****");
            Console.WriteLine();

            // Point using int
            Point<int> p = new Point<int>(10, 10);

            Console.WriteLine(p.ToString());
            Console.WriteLine("-> Reset Point");
            p.ResetPoint();
            Console.WriteLine(p.ToString());

            Console.WriteLine();

            // Point using double
            Point<double> p2 = new Point<double>(5.4, 6.4);

            Console.WriteLine(p2.ToString());
            Console.WriteLine("-> Reset Point");
            p2.ResetPoint();
            Console.WriteLine(p2.ToString());
            Console.WriteLine();
        }
    }
}