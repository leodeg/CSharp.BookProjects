using System;
using System.Collections.Generic;
using System.Data;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace IndexersExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MultipleIndexerDataTable();
        }

        private static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            DisplayYellow("----------- First Display -----------\n");

            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person Number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }

            DisplayYellow("\n=> Change Lisa to Maggie\n");

            myPeople[0] = new Person("Maggie", "Simpson", 2);

            DisplayYellow("----------- Second Display -----------\n");

            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person Number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }

        private static void UseGenericDictionaryListOfPeople()
        {
            PersonDictionaryCollection people = new PersonDictionaryCollection();
            people["Homer"] = new Person("Homer", "Simpson", 40);
            people["Marge"] = new Person("Marge", "Simpson", 38);

            // Get Homer and print data
            Person homer = people["Homer"];
            DisplayYellow("Print Homer");
            Console.WriteLine(homer.ToString());

            // Get Marge and print data
            Person marge = people["Marge"];
            DisplayYellow("\nPrint Marge");
            Console.WriteLine(marge.ToString());
        }

        private static void MultipleIndexerDataTable()
        {
            // Make DataTable with 3 columns
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("FirstName"));
            table.Columns.Add(new DataColumn("LastName"));
            table.Columns.Add(new DataColumn("Age"));

            // Add a row to the table
            table.Rows.Add("Mel", "Appleby", 60);

            // Use multidimension indexer to get details of first row.
            Console.WriteLine("First Name: {0}", table.Rows[0][0]);
            Console.WriteLine("Last Name: {0}", table.Rows[0][1]);
            Console.WriteLine("Age: {0}", table.Rows[0][2]);
        }

        private static void DisplayYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}