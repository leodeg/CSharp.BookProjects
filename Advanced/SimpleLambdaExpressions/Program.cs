using System;
using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //-----------------------------------------------------------------------------
            // Test Lambda expression
            //-----------------------------------------------------------------------------

            Console.WriteLine("Traditional Delegate Syntax");
            TraditionalDelegateSyntax();

            Console.WriteLine("\nAnonymous Method Syntax");
            AnonymousMethodSyntax();

            Console.WriteLine("\nLambda Expression Syntax");
            LambdaExpressionSyntax();

            Console.WriteLine("\nLambda Expression Syntax And Display Data");
            LambdaExpressionSyntaxAndDisplayElements();

            //-----------------------------------------------------------------------------

            Console.WriteLine("\nSimple math");
            UseSimpleMath();
        }

        //-----------------------------------------------------------------------------
        // Lambda expression
        //-----------------------------------------------------------------------------

        private static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your even number:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("|\t{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        // Target of the Predicate<T> delegate.
        private static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        private static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(delegate (int i)
            { return i % 2 == 0; });

            Console.WriteLine("Here are your even number:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("|\t{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        private static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll(number => (number % 2) == 0);

            Console.WriteLine("Here are your even number:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("|\t{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        private static void LambdaExpressionSyntaxAndDisplayElements()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll((number) =>
            {
                Console.WriteLine("Value of 'number' is currently: {0}", number);
                return number % 2 == 0;
            });

            Console.WriteLine("Here are your even number:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("|\t{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        private static void UseSimpleMath()
        {
            SimpleMath simpleMath = new SimpleMath();
            simpleMath.SetMathHandler((msg, result) => Console.WriteLine("Message: {0}, Result: {1}", msg, result));

            simpleMath.Add(10, 10);
            Console.WriteLine();

            SimpleMath.VerySimpleDelegate verySimpleDelegate = new SimpleMath.VerySimpleDelegate(() => "Enjoy your string!");
        }

        //-----------------------------------------------------------------------------
        // More power of the lambda expression
        //-----------------------------------------------------------------------------

        public class SimpleMath
        {
            public delegate void MathMessage(string msg, int result);

            private MathMessage mathMsgDelegate;

            public delegate string VerySimpleDelegate();

            public void SetMathHandler(MathMessage target)
            {
                mathMsgDelegate = target;
            }

            public void Add(int x, int y)
            {
                mathMsgDelegate?.Invoke("Adding has completed!", x + y);
            }
        }
    }
}