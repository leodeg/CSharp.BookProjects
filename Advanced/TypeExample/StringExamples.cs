using System;

namespace Advanced
{
    internal static class StringExamples
    {
        public static void BasicStringFunctionlity()
        {
            Console.WriteLine("=> Basic String Functionality:");

            const string firstName = "Freddy";

            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters", firstName.Length);
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", " "));
            Console.WriteLine();
        }

        public static void StringComparesRules()
        {
            const string s1 = "Super";
            const string s2 = "John";

            Console.WriteLine("Default rules: s1={0}, s2={1}.s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));

            Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}", s1.Equals(s2, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Ignore case, Invarariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));

            Console.WriteLine();

            Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));

            Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Ignore case, Invarariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));

            Console.WriteLine();
        }

        public static void StringNotChanges()
        {
            const string str1 = "The first string";
            Console.WriteLine(str1);
            Console.WriteLine(str1.ToUpper());
            Console.WriteLine(str1);
        }

        public static void StringAreImmutable()
        {
            string str1 = "The first string";
            str1 = "The second string";
        }

        public static void StringInterpolation(string firstMame = "DefaultName")
        {
            Console.WriteLine($"Hello {firstMame}! Glad to see you.");
        }
    }
}