using System;

namespace Advanced
{
    /// <summary>
    /// Simple person class
    /// </summary>
    public class Person
    {
        private readonly string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetName() => name;

        public int GetAge() => age;

        public void Display()
        {
            Console.WriteLine($"Name = {name}, Age = {age}");
        }

        // Simple method example how to send a reference type like a reference
        private static void SendAPersonByReference(ref Person p)
        {
            p.age = 555;
            p = new Person("Nikki", 999);
        }

        public static void Testing()
        {
            Console.WriteLine("**** Passing Person object by reference ****");

            Person melony = new Person("Melony", 23);
            Console.WriteLine("Before by ref call, Person is: ");
            melony.Display();

            SendAPersonByReference(ref melony);
            Console.WriteLine("After by ref call, Person is: ");
            melony.Display();

            Console.ReadLine();
        }
    }
}