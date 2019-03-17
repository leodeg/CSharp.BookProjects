using static OOPExample.InheritanceHasA;

namespace Advanced
{
    /// <summary>
    /// Properties example
    /// </summary>
    internal class PropertiesExample
    {
        // Read-only property? This is OK!
        public int ReadOnlyProp { get; }

        // Write only property? Error!
        //public int WriteOnlyProp { set; }

        public int PrivateSetProperty { get; private set; }
        public int PrivateSetProperty2 { get; }

        public int PrivateGetProperty { private get; set; }

        private int PrivateProperty { get; set; }

        // The hidden int backing field is set to zero!
        public int NumbersOfCars { get; set; }

        // The hidden Car backing field is set to null!
        // Return "a null reference exception"
        public Car MyAuto { get; set; }
    }
}