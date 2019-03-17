using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GenericCollections
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UseObservableCollection();
        }

        // -------------------------------------------------------------------

        private static void SimpleBoxingOperation()
        {
            // Make value type (int) variable
            int unboxedValue = 25;

            // Box the int value to object reference
            object boxedValue = unboxedValue;

            // And again make from boxed value to unboxed
            int newUnboxedValue = (int)boxedValue;
        }

        // -------------------------------------------------------------------

        private static void SimpleWrongBoxingOperation()
        {
            // Make value type (int) variable
            int unboxedValue = 25;

            // Box the int value to object reference
            object boxedValue = unboxedValue;

            // Unbox in the wrong data type to trigger
            // runtime exception.
            try
            {
                long newUnboxedValue = (long)boxedValue;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // -------------------------------------------------------------------

        private static void WorkWithArrayList()
        {
            // Value type are automatically boxed when
            // passed to a member requesting an object
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(20);
            arrayList.Add(30);
            arrayList.Add(40);
            arrayList.Add(35);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            arrayList.Reverse();

            Console.WriteLine();
            Console.WriteLine("Reverse arrayList");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            arrayList.Remove(30);

            Console.WriteLine();
            Console.WriteLine("Remove '30' from the arrayList");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Unboxing occurs when an object is converted back to
            // stack-based data.
            int unboxingValue = (int)arrayList[0];

            Console.WriteLine();
            Console.WriteLine("Value of your int: {0}", unboxingValue);
        }

        // -------------------------------------------------------------------

        private static void WorkWithCustomPersonCollection()
        {
            // Create a new Person collection
            PersonCollection personCollection = new PersonCollection();

            // Add a new person to the PersonCollection
            personCollection.AddPerson(new Person("Homer", "Simpson", 40));
            personCollection.AddPerson(new Person("Marge", "Simpson", 38));
            personCollection.AddPerson(new Person("Lisa", "Simpson", 9));
            personCollection.AddPerson(new Person("Bart", "Simpson", 7));
            personCollection.AddPerson(new Person("Maggie", "Simpson", 2));

            // Display the all persons in the PersonColletion
            foreach (Person person in personCollection)
            {
                Console.WriteLine(person);
            }

            // This would be a compile-time error
            // personCollection.AddPerson(new Car());
        }

        // -------------------------------------------------------------------

        private static void UseGenericList()
        {
            // This list can hold only Person objects.
            List<Person> people = new List<Person>();
            people.Add(new Person("Frank", "Black", 49));

            Console.WriteLine(people[0]);
            Console.WriteLine();

            // This list can hold only integers.
            List<int> integers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                integers.Add(i * 5 / 3);
            }

            foreach (int integer in integers)
            {
                Console.Write(integer + ", ");
            }
            Console.WriteLine();
        }

        // -------------------------------------------------------------------

        private static void UsePersonGenericList()
        {
            // Create a new List of people
            List<Person> people = new List<Person>()
            {
                new Person("Homer", "Simpson", 40),
                new Person("Marge", "Simpson", 38),
                new Person("Lisa", "Simpson", 9),
                new Person("Bart", "Simpson", 7),
            };

            // Print out # of items in List.
            Console.WriteLine("Items in List: {0}", people.Count);
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            // Check how many people are in the list.
            Console.WriteLine("\n-> Inserting new person.");

            // Add new person to the list of people.
            people.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });

            // Check how many people are in the list now.
            Console.WriteLine("Items in List: {0}", people.Count);

            Console.WriteLine();
            // Copy data int a new array.
            Person[] arrayOfPeople = people.ToArray();
            foreach (Person person in arrayOfPeople)
            {
                Console.WriteLine("First name: {0}", person.FirstName);
            }
            Console.WriteLine();
        }

        // -------------------------------------------------------------------

        private static void UseGenericStack()
        {
            // Create a Stack of Person
            Stack<Person> stackOfPeople = new Stack<Person>();

            // Add a new person in the stack of people
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 38 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Now look at the top item, pop it, and look again.
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped of {0}", stackOfPeople.Pop());

            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped of {0}", stackOfPeople.Pop());

            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped of {0}", stackOfPeople.Pop());

            // Try get a next item in the stack.
            try
            {
                Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
            }
        }

        // -------------------------------------------------------------------

        // Just a helper method for the Queue example
        private static void GetCoffee(Person person)
        {
            Console.WriteLine("{0} get coffee!", person.FirstName);
        }

        private static void UseGenericQueue()
        {
            // Create a new Queue of Person
            Queue<Person> peopleQ = new Queue<Person>();

            // Add a new people to the queue of Person
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 38 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Peek at first person in Q.
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);

            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error! {0}", ex.Message);
            }
        }

        // -------------------------------------------------------------------

        private static void UseSortedSet()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person("Homer", "Simpson", 40),
                new Person("Marge", "Simpson", 38),
                new Person("Lisa", "Simpson", 9),
                new Person("Bart", "Simpson", 7),
            };

            foreach (Person person in setOfPeople)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            setOfPeople.Add(new Person("Saku", "Jones", 1));
            setOfPeople.Add(new Person("Mikko", "Jones", 32));

            foreach (Person person in setOfPeople)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();
        }

        // -------------------------------------------------------------------

        private static void UseDictionary()
        {
            // Populate using Add() method.
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            peopleA.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            peopleA.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Get Lisa, Homer, and Marge.
            Person lisaA = peopleA["Lisa"];
            Person homerA = peopleA["Homer"];
            Person margeA = peopleA["Marge"];

            Console.WriteLine("**** People variant a ****");

            Console.WriteLine(lisaA);
            Console.WriteLine(homerA);
            Console.WriteLine(margeA);

            //------------------------------------------------------------------

            // Populate with initialization syntax.
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                {"Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 }},
                {"Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 }},
                {"Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }}
            };

            // Get Lisa, Homer, and Marge.
            Person lisaB = peopleB["Lisa"];
            Person homerB = peopleB["Homer"];
            Person margeB = peopleB["Marge"];

            Console.WriteLine();
            Console.WriteLine("**** People variant b ****");

            Console.WriteLine(lisaB);
            Console.WriteLine(homerB);
            Console.WriteLine(margeB);

            //------------------------------------------------------------------

            // Populate with initialization syntax.
            Dictionary<string, Person> peopleC = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
            };

            Person lisaC = peopleC["Lisa"];
            Person homerC = peopleC["Homer"];
            Person margeC = peopleC["Marge"];

            Console.WriteLine();
            Console.WriteLine("**** People variant c ****");

            Console.WriteLine(lisaC);
            Console.WriteLine(homerC);
            Console.WriteLine(margeC);
        }

        // -------------------------------------------------------------------

        public enum NotifyCollectionChangedAction
        {
            Add = 0,
            Remove = 1,
            Replace = 2,
            Move = 3,
            Reset = 4
        }

        private static void PeopleCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action for this event: {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items: ");
                foreach (Person person in e.OldItems)
                {
                    Console.WriteLine(person.ToString());
                }
                Console.WriteLine();
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Here are the NEW items:");
                foreach (Person person in e.NewItems)
                {
                    Console.WriteLine(person.ToString());
                }
            }
        }

        private static void UseObservableCollection()
        {
            // Make a collection to observe and add a few Person objects.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person {FirstName = "John", LastName = "Murphy", Age = 36},
                new Person {FirstName = "Kevin", LastName = "Key", Age = 28}
            };
            // Wire up the CollectionChanged event.
            people.CollectionChanged += PeopleCollectionChanged;
        }
    }
}