using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced
{

    static class PatternMatchingSwitch
    {
        /// <summary>
        /// The execute pattern matching switch
        /// </summary>
        public static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.WriteLine("Please choose an option");

            string userChoice = Console.ReadLine();
            object choice;

            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }

            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer {0}", i);
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string {0}", s);
                    break;
                case decimal d:
                    Console.WriteLine("Your choice is a decimal {0}", d);
                    break;
                default:
                    Console.WriteLine("Your choice is something else");
                    break;
            }
            Console.WriteLine();
        }
    }
}
