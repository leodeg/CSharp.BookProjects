using System;

namespace Delegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UseGenericDelegate();
        }

        //------------------------------------------------------------------------------

        private static void DisplayDelegateInfo(Delegate delegateObject)
        {
            foreach (Delegate del in delegateObject.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", del.Method);
                Console.WriteLine("Type Name: {0}", del.Target);
            }
        }

        //------------------------------------------------------------------------------

        private static void UseStaticAndNonStaticMehods()
        {
            // Get static methods.
            BinaryOP addOp = new BinaryOP(SimpleMath.Add);
            DisplayDelegateInfo(addOp); // Don't have the Type Name, because Add() is static method.

            Console.WriteLine();
            // Get nonstatic methods.
            SimpleMath simpleMath = new SimpleMath();
            BinaryOP multOp = new BinaryOP(simpleMath.Mult);
            DisplayDelegateInfo(multOp); // The Type Name is Delegates.SimpleMath.

            Console.WriteLine();
            Console.WriteLine("10 * 10 is {0}", multOp(10, 10));
            Console.WriteLine("10 + 10 is {0}", addOp(10, 10));
        }

        //------------------------------------------------------------------------------
        // Delegate test methods
        //------------------------------------------------------------------------------

        private static void UseCarDelegate()
        {
            Car carOne = new Car("SlugBerry", 100, 10);

            // Register multiple targets for the notifications.
            carOne.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            carOne.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEventTwo));

            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                carOne.Accelerate(20);
            }
        }

        private static void UseCarDelegateTwo()
        {
            // First, make a Car object.
            Car carOne = new Car("SlugBerry", 100, 10);
            carOne.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            // This time, hold onto the delegate object,
            // so we cant unregister later.
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEventTwo);
            carOne.RegisterWithCarEngine(handler2);

            // Speed up.
            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                carOne.Accelerate(20);
            }

            // Unregister from the second handler.
            carOne.UnRegisterWithCarEngine(handler2);

            // We won't see the 'uppercase' message anymore!
            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                carOne.Accelerate(20);
            }
        }

        // We have TWO methods that will be called by the Car
        // when sending notifications.
        // Lowercase display.
        private static void OnCarEngineEvent(string messageForCaller)
        {
            Console.WriteLine("\n**** Message From Car Object **** ");
            Console.WriteLine("=> {0}", messageForCaller);
        }

        // Uppercase display.
        private static void OnCarEngineEventTwo(string messageForCaller)
        {
            Console.WriteLine("=> {0}", messageForCaller.ToUpper());
            Console.WriteLine();
        }

        //------------------------------------------------------------------------------
        // Method Group Conversion
        //------------------------------------------------------------------------------

        private static void MethodGroupConversion()
        {
            Car carOne = new Car();

            // Register the simple method name.
            carOne.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                carOne.Accelerate(20);
            }

            // Unregister the simple method name.
            carOne.UnRegisterWithCarEngine(CallMeHere);

            // No more notifications!
            for (int i = 0; i < 6; i++)
            {
                carOne.Accelerate(20);
            }
            Console.WriteLine();
        }

        private static void CallMeHere(string messageForCaller)
        {
            Console.WriteLine("=> Message from Car: {0}", messageForCaller);
        }

        //------------------------------------------------------------------------------
        // Generic Delegates
        //------------------------------------------------------------------------------

        public delegate void GenericDelegate<T>(T arg);

        private static void UseGenericDelegate()
        {
            GenericDelegate<string> strTarget = new GenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            GenericDelegate<int> intTarget = new GenericDelegate<int>(IntTarget);
            intTarget(15);
        }

        // Return Uppercase
        private static void StringTarget(string args)
        {
            Console.WriteLine("argument in uppercase is: {0}", args.ToUpper());
        }

        // Return incremented value of the argument
        private static void IntTarget(int arg)
        {
            Console.WriteLine("++argument is: {0}", ++arg);
        }
    }

    //------------------------------------------------------------------------------
    // Delegate using example
    //------------------------------------------------------------------------------

    public delegate int BinaryOP(int x, int y);

    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;

        public static int Subtract(int x, int y) => x - y;

        public static int SquareNumber(int x) => x * x;

        public int Mult(int x, int y) => x * y;
    }

    public static class Test
    {
        public static void TestSimpleMath()
        {
            // Create a BinaryOP delegate object that
            // 'points to' SimpleMath.Add.
            BinaryOP del = new BinaryOP(SimpleMath.Add);

            // Invoke Add method indirectly using delegate object
            Console.WriteLine("10 + 10 is {0}", del(10, 10));
            Console.WriteLine();

            // Add a Subtract method to the delegate.
            del += SimpleMath.Subtract;

            // Invoke Subtract indirectly using delegate object.
            Console.WriteLine("30 - 15 is {0}", del(30, 15));
            Console.WriteLine();
        }
    }

    //------------------------------------------------------------------------------
}