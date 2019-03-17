using System.Collections;
using System.Collections.Generic;

namespace IndexersExample
{
    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Name : {FirstName} {LastName}; Age: {Age}";
        }
    }

    public class PersonArrayListCollection : IEnumerable
    {
        // Cast for caller.
        private ArrayList arrayOfPeople = new ArrayList();

        // Custom indexer for this class.
        public Person this[int index]
        {
            get => (Person)arrayOfPeople[index];
            set => arrayOfPeople.Insert(index, value);
        }

        public Person GetPerson(int position)
        {
            return (Person)arrayOfPeople[position];
        }

        /// <summary>
        /// Insert only Person objects.
        /// </summary>
        public void AddPerson(Person person)
        {
            arrayOfPeople.Add(person);
        }

        public void ClearPeople()
        {
            arrayOfPeople.Clear();
        }

        public int Count { get { return arrayOfPeople.Count; } }

        // Foreach enumeration support.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return arrayOfPeople.GetEnumerator();
        }
    }

    public class PersonDictionaryCollection : IEnumerable
    {
        private Dictionary<string, Person> listOfPeople = new Dictionary<string, Person>();

        // The indexer returns a person based on string index
        public Person this[string name]
        {
            get => (Person)listOfPeople[name];
            set => listOfPeople[name] = value;
        }

        public void ClearPeople() => listOfPeople.Clear();

        public int Count => listOfPeople.Count;

        IEnumerator IEnumerable.GetEnumerator() => listOfPeople.GetEnumerator();
    }

    public class SortPeopleByAge : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person firstPerson, Person secondPerson)
        {
            if (firstPerson?.Age > secondPerson?.Age)
            {
                return 1;
            }
            if (firstPerson?.Age < secondPerson?.Age)
            {
                return -1;
            }
            return 0;
        }
    }
}