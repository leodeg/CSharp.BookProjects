using System;

namespace TypeExample
{
    internal class NullableExample
    {
        // Nullable types

        public static void LocalNullableDeclaration()
        {
            //int intValue = null; //Error. Int is a value type
            string str = null; //Ok! String is a reference type
        }

        public static void LocalNullableVariables()
        {
            // Some local nullable variables
            int? nullableInt = 10;
            double? nullDouble = 1.0;
            bool? nullBool = false;

            //Error! String is reference types!
            //string? str = "yeah";
        }

        public static void LocalNullableVariablesUsingNullable()
        {
            // Some local nullable types using Nullable<T>
            Nullable<int> nullableInt = 10; // Equal = "int? nullableInt = 10"
            Nullable<double> nullableDouble = 10.0;
            Nullable<bool> nullableBool = false;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }

        /// <summary>
        /// Nullable example class
        /// </summary>
        public class DatabaseReader
        {
            // Nullable data field
            private int? numericalValue = null;

            private bool? boolValue = null;

            // The nullable return type
            public int? GetIntFromDatabase() => numericalValue;

            public bool? GetBoolFromDatabase() => boolValue;

            public void SetIntToDatabase(int value) => numericalValue = value;

            public void SetBoolToDatabase(bool value) => boolValue = value;

            public static void Testing()
            {
                Console.WriteLine("*** Fun with Nullable Data ***");

                DatabaseReader databaseReader = new DatabaseReader();

                // Return 100
                int myData = databaseReader.GetIntFromDatabase() ?? 100;
                Console.WriteLine("Value of myData: {0}", myData);

                // Set new value to intValue
                databaseReader.SetIntToDatabase(15);

                // Return 15
                myData = databaseReader.GetIntFromDatabase() ?? 100;
                Console.WriteLine("Value of myData: {0}", myData);
            }
        }
    }
}