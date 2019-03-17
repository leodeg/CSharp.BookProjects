using System;

namespace Advanced
{
    /// <summary>
    /// Example of value types
    /// </summary>
    internal static class TypeExamples
    {
        public static void IntSeparator()
        {
            int number = 192_168_527;
            Console.WriteLine(number);
        }

        // Checked and Unchecked

        public static void OverflowCheckedSum(byte byteNumber1, byte byteNumber2)
        {
            try
            {
                byte sum = checked((byte)(byteNumber1 + byteNumber2));
                Console.WriteLine("sum = {0}", sum);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void OverflowCheckedScopeSum(byte byteNumber1, byte byteNumber2)
        {
            try
            {
                checked
                {
                    byte sum = (byte)(byteNumber1 + byteNumber2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Reference

        public static ref string SampleRefReturn(string[] stringArray, int position)
        {
            return ref stringArray[position];
        }

        public static void SampleRefReturnExample()
        {
            Console.WriteLine("Use Ref Return");

            string[] stringArray = { "one", "two", "three" };

            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);

            // Add "new" to string array by references from SampleRefReturn
            ref var refOutput = ref SampleRefReturn(stringArray, 1);
            refOutput = "new";

            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
        }
    }
}