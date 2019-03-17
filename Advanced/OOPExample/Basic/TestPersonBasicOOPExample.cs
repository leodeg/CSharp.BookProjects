using System;

namespace Advanced
{
    static partial class OOPExample
    {
        /// <summary>
        /// Basic example of OOP with person class
        /// </summary>
        private class TestPerson
        {
            public String Name { get; set; }
            public String Address { get; set; }

            public TestPerson(string name, string address)
            {
                Name = name;
                Address = address;
            }
        }
    }
}