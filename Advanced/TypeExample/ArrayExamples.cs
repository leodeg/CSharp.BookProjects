using System;

namespace Advanced
{
    internal static class ArrayExamples
    {
        public static void ArrayInitializationType()
        {
            Console.WriteLine("Array Initialization of type");

            string[] stringArrayNew = new string[] { };
            string[] stringArrayScope = { };
            string[] stringArraySizeAndNew = new string[4] { "John", "Mari", "Mario", "Maria" };
        }

        public static void ArrayInitializationVar()
        {
            Console.WriteLine("Array Initialization of var type");

            var arrayOfReallyInt = new[] { 1, 10, 20, 30 };
            var arrayOfReallyDouble = new[] { 1.20, 2.20, 3.30 };
            var arrayOfString = new[] { "hello", "goodbye" };
        }

        public static void ArrayInitializationObject()
        {
            Console.WriteLine("Array Initialization of objects");

            object[] arrayOfObjects = new object[4]
            {
                10,
                false,
                new DateTime(1969, 10, 25),
                "Form & Void"
            };

            foreach (var obj in arrayOfObjects)
            {
                Console.WriteLine("Type: {0}, Value: {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }
    }
}