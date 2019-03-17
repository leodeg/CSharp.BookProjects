using System;

namespace TypeExample
{
    internal class TupleExample
    {
        /// <summary>
        /// Tuple's example
        /// </summary>
        public static class TuplesExample
        {
            public static void TuplesDeclaration()
            {
                Console.WriteLine("=> Declaration of Tuples");

                Console.WriteLine();

                //--------------------------------------------------------------

                // Full declaration without names
                (string, int, string) person = ("John", 19, "Brown");

                // Declaration with Var
                var person2 = ("John", 19, "Brown");

                // Full declaration with names
                (string firstName, string lastName, int age) personInformarion = ("John", "Brown", 19);

                //--------------------------------------------------------------

                // Ignore Name in right side
                (int, int) example = (Custom1: 5, Custom: 7);
                (int Field1, int Field2) example2 = (Custom1: 5, Custom2: 7);

                // Ok! Using var types.
                var example3 = (Custom1: 5, Custom2: 10);

                //--------------------------------------------------------------

                Console.WriteLine("=> Display Tuples");

                Console.WriteLine();

                Console.WriteLine("**** First Person Information ****");

                Console.WriteLine($"First item: {person.Item1}");
                Console.WriteLine($"Second item: {person.Item2}");
                Console.WriteLine($"Third item: {person.Item3}");

                Console.WriteLine();

                Console.WriteLine("**** Second Person Information ****");

                Console.WriteLine($"Person firstName: {personInformarion.Item1}");
                Console.WriteLine($"Person lastName: {personInformarion.Item2}");
                Console.WriteLine($"Person age: {personInformarion.Item3}");

                Console.WriteLine();
            }

            public static void InferredVariableNames()
            {
                var foo = new { Prop = "first", Prop2 = "second" };
                var bar = new { foo.Prop, foo.Prop2 };

                Console.WriteLine($"Foo = {foo.Prop}, {foo.Prop2}");
                Console.WriteLine($"Bar = {bar.Prop}, {bar.Prop2}");
            }

            public static (string firstName, string lastName, int age) FillTheseValues()
            {
                return ("DefaultFirstName", "DefaultLastName", 0);
            }

            public static void FillTheseValuesTest()
            {
                var samples = FillTheseValues();
                Console.WriteLine($"FirstName = {samples.firstName}");
                Console.WriteLine($"LastName = {samples.lastName}");
                Console.WriteLine($"Age = {samples.age}");
            }

            public static void DiscardTuples()
            {
                //var (first, _, last) = SplitNames("Philip F Japikse");
            }
        }
    }
}