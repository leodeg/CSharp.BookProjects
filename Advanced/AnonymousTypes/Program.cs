using System;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AnonymousTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EqualityTest();

            Console.WriteLine();
        }

        private static void EqualityTest()
        {
            //-----------------------------------------------------------------------------

            var firstCar = new { Color = "BrightPink", Make = "Saab", CurrentSpeed = 55 };
            var secondCar = new { Color = "BrightPink", Make = "Saab", CurrentSpeed = 55 };

            //-----------------------------------------------------------------------------

            if (firstCar.Equals(secondCar))
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            //-----------------------------------------------------------------------------

            if (firstCar == secondCar)
                Console.WriteLine("Same anonymous object!");
            else
                Console.WriteLine("Not the same anonymous object!");

            //-----------------------------------------------------------------------------

            if (firstCar.GetType().Name == secondCar.GetType().Name)
                Console.WriteLine("We are both the same type!");
            else
                Console.WriteLine("We are different types!");

            //-----------------------------------------------------------------------------

            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }

        private static void BuildAnonymousType(string make, string color, int currentSpped)
        {
            // Build anonymous type using incoming args.
            var car = new { Make = make, Color = color, Speed = currentSpped };

            Console.WriteLine("You have  a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);

            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        private static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} if {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
            Console.WriteLine();
        }
    }
}