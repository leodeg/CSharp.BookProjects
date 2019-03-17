using System;

namespace OOPExample.Basic
{
    internal class CastingRules
    {
        protected class Employee
        {
            //------------------------------------------------------------------

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public byte Age { get; set; }

            //------------------------------------------------------------------

            public Employee()
            {
            }

            public Employee(string firstName)
                : this(firstName, "DefaultLastName", 0) { }

            public Employee(string firstName, string lastName)
                : this(firstName, lastName, 0) { }

            public Employee(string firstName, string lastName, byte age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }

            //------------------------------------------------------------------

            public void Display()
            {
                Console.WriteLine("Full name : {1} {2}, \nAge: {3},", FirstName, LastName, Age);
            }

            //------------------------------------------------------------------

            public override string ToString()
            {
                return $"First Name: {FirstName}; Last Name: {LastName}; Age = {Age}]";
            }

            // Check Equals by ToString method
            //public override bool Equals(object obj) => obj?.ToString() == this.ToString();

            public override bool Equals(object obj)
            {
                if (obj is Person && obj != null)
                {
                    Person temp;
                    temp = (Person)obj;
                    if (temp.FirstName == this.FirstName
                        && temp.LastName == this.LastName
                        && temp.Age == this.Age)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            //------------------------------------------------------------------
        }

        private class Person : Employee
        {
            //------------------------------------------------------------------

            public Person()
                : base() { }

            public Person(string firstName)
                : base(firstName) { }

            public Person(string firstName, string lastName)
                : base(firstName, lastName) { }

            public Person(string firstName, string lastName, byte age)
                : base(firstName, lastName, age) { }

            //------------------------------------------------------------------
        }

        public static class Testing
        {
            public static void ObjectCastingExample()
            {
                // A Manager "is-a" System.Object, so we can
                // store a Manager reference in an object variable just fine.
                object frank = new Person("Frank");
                ((Person)frank).Display();
                ((Employee)frank).Display();
            }

            //------------------------------------------------------------------

            public static void CastingExample()
            {
                Console.WriteLine("**** Persons ****");

                Employee fred = new Person("Fred");
                fred.Display();

                Person john = new Person("John");
                john.Display();

                //--------------------------------------------------------

                Console.WriteLine("**** Array of persons (Employee) ****");

                Employee[] persons = { new Person("Frederica"), new Person("Johnson") };

                foreach (var person in persons)
                {
                    person.Display();
                }

                //--------------------------------------------------------

                Console.WriteLine("**** Casting by 'as' ****");

                Person employee = new Employee("Rodson") as Person;
                // Return null
                employee?.Display();
            }

            //------------------------------------------------------------------

            public static void CastingExample2()
            {
                Employee employee = new Employee("Ronsod");
                // Error! Can't cast employee to a person.
                // But this compiles fine!
                Person employeeCasting = (Person)employee;
                // Return Error
                employeeCasting?.Display();
            }

            //------------------------------------------------------------------

            public static void ObjectMainOverview()
            {
                // Implementation
                Object newObject = new Object();

                // Basic methods
                Console.WriteLine(newObject.ToString());
                Console.WriteLine("Object type: {0}", newObject.GetType());
                Console.WriteLine("Hash code: {0}", newObject.GetHashCode());

                // Yeah, it's very logical condition
                if (newObject.Equals(newObject))
                {
                    Console.WriteLine("Is the same object");
                }
            }

            //------------------------------------------------------------------

            public static void TestOverridedMethods()
            {
                Person p1 = new Person("Homer", "Simpson", 50);
                Person p2 = new Person("Homer", "Simpson", 50);

                // Get string method
                Console.WriteLine("p1.ToString: {0}", p1.ToString());
                Console.WriteLine("p2.ToString: {0}", p2.ToString());

                // Test overridden Equals()
                Console.WriteLine("p1 == p2? : {0}", p1.Equals(p2));

                // Test hash codes
                Console.WriteLine("Same hash code?: {0}", p1.GetHashCode() == p2.GetHashCode());

                Console.WriteLine("");

                // Change age and test again
                p2.Age = 45;
                Console.WriteLine("p1.ToString: {0}", p1.ToString());
                Console.WriteLine("p2.ToString: {0}", p2.ToString());
                Console.WriteLine("p1 == p2? : {0}", p1.Equals(p2));
                Console.WriteLine("Same hash code?: {0}", p1.GetHashCode() == p2.GetHashCode());
            }
        }
    }
}