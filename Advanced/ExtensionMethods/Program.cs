using System;

//using System.Collections.Generic;
//using System.Linq;
using System.Reflection;

//using System.Text;
//using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UseExtensionMethods();
        }

        private static void UseExtensionMethods()
        {
            // The int has assumed a new identity!
            int integer = 1234567;
            integer.DisplayDefiningAssembly();

            // So has the DataSet.
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.DisplayDefiningAssembly();

            // And the SoundPlayer.
            System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.DisplayDefiningAssembly();

            // Use new integer functionality.
            Console.WriteLine();
            Console.WriteLine("Value of integer is: {0}", integer);
            Console.WriteLine("Reversed digits of integer is: {0}", integer.ReverseInteger());

            Console.WriteLine();
        }
    }

    /// <summary>
    /// Extension methods container.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Display the assembly it is defined in.
        /// </summary>
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here: {1}", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        /// <summary>
        /// Reverse integer value.
        /// </summary>
        public static int ReverseInteger(this int number)
        {
            // Translate into a string, and then get all the characters.
            char[] digits = number.ToString().ToCharArray();
            // Reverse items in the array of char.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);
            // Return the modified string back as an int.
            return int.Parse(newDigits);
        }
    }
}