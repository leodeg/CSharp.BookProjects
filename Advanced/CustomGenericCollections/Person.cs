using System.Collections;
using System.Collections.Generic;

namespace CustomGenericCollections
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

    public class PersonCollection : IEnumerable
    {
        // Cast for caller.
        private ArrayList arrayOfPeople = new ArrayList();

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