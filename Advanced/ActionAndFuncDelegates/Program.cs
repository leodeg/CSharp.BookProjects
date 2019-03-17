using System;

namespace ActionAndFuncDelegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //------------------------------------------------------------------------------

            Console.WriteLine("**** Fun with Action and Func ****");
            Console.WriteLine();

            //------------------------------------------------------------------------------

            UseEventExample();

            //------------------------------------------------------------------------------

            Console.WriteLine();
        }

        //------------------------------------------------------------------------------
        // Use methods
        //------------------------------------------------------------------------------

        private static void UseActionMethod()
        {
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);

            actionTarget("Action message!", ConsoleColor.Yellow, 10);
        }

        private static void UseFuncMethod()
        {
            // Store int method
            // First implementation
            //Func<int, int, int> intTarget = new Func<int, int, int>(Add);

            // Second implementation
            Func<int, int, int> intTarget = Add;
            int result = intTarget.Invoke(40, 40);
            Console.WriteLine(result);

            // Store string method
            // First implementation
            //Func<int, int, string> stringTarget = new Func<int, int, string>(SumToString);

            // Second implementation
            Func<int, int, string> stringTarget = SumToString;
            string sum = stringTarget.Invoke(20, 30);
            Console.WriteLine(sum);
        }

        private static void UseEventExample()
        {
            Console.WriteLine("**** Agh! No Encapsulation! ****");
            // Make a car
            Car myCar = new Car();

            // We have direct access to the delegate!
            myCar.listOfHandlers = new Car.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);

            // We can now assign to a whole new object
            // confusing at best.
            myCar.listOfHandlers = new Car.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);

            // The caller can also directly invoke the delegate!
            myCar.listOfHandlers.Invoke("hee, hee, hee...");
        }

        //------------------------------------------------------------------------------
        // Helper methods
        //------------------------------------------------------------------------------

        private static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            // Display message
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color of console.
            Console.ForegroundColor = previous;
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        private static void CallWhenExploded(string msgForCaller)
        {
            Console.WriteLine(msgForCaller);
        }

        private static void CallHereToo(string msgForCaller)
        {
            Console.WriteLine(msgForCaller);
        }

        //------------------------------------------------------------------------------
    }
}