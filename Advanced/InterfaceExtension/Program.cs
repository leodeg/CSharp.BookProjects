using System;
using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace InterfaceExtension
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UseAnnoyingExtensionsMethod();
        }

        private static void UseAnnoyingExtensionsMethod()
        {
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!" };

            data.PrintDataAndBeep();

            Console.WriteLine();

            List<int> integer = new List<int>() { 10, 15, 20 };
            integer.PrintDataAndBeep();

            Console.WriteLine();
        }
    }

    internal static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
}