using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjects
{
    internal class Program
    {
        private static void Main (string[] args)
        {
            //QueryOverString();
            //Console.WriteLine();

            //QueryOVerStringWithExtensionMethods();
            //Console.WriteLine();

            //QueryOVerStringLongHand();
            //Console.WriteLine();

            //QueryOverInt();
            //Console.WriteLine();

            //QueriesToCollectionObjects();
            //Console.WriteLine();

            //LinqOverArrayList();
            //Console.WriteLine();

            //LinqProductInfo();
            //Console.WriteLine();

            Query_ByAnonymousMethod();
            Console.WriteLine();

        }

        private static void QueryOverString ()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter" };

            IEnumerable<string> subset = from game in currentVideoGames
                                         where game.Contains(" ")
                                         orderby game
                                         select game;

            ReflectiOverQueryResults(subset);

            foreach (string game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }
        }

        private static void QueryOVerStringWithExtensionMethods ()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter" };

            IEnumerable<string> subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            ReflectiOverQueryResults(subset, "Extension Methods");

            if (subset != null)
            {
                foreach (string game in subset)
                {
                    Console.WriteLine("Item: {0}", game);
                }
            }
        }

        private static void QueryOVerStringLongHand ()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Dexter" };
            string[] gamesWithSpaces = new string[5];

            // Find a video games that contain white spaces
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                {
                    gamesWithSpaces[i] = currentVideoGames[i];
                }
            }

            Array.Sort(gamesWithSpaces);

            ReflectiOverQueryResults(gamesWithSpaces, "Long Hand");

            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                {
                    Console.WriteLine("Item: {0}", s);
                }
            }
        }

        private static void QueryOverInt ()
        {
            int[] numbers = { 1, 5, 6, 15, 50, 4, 56 };
            IEnumerable<int> subset = from integer in numbers
                                      where integer < 10
                                      select integer;

            ReflectiOverQueryResults(subset, "Over integers");

            foreach (var integer in subset)
            {
                Console.Write(integer + ", ");
            }
        }

        private static void QueriesToCollectionObjects ()
        {
            Console.WriteLine("\n**** Play with queries and cars");
            List<Car> cars = new List<Car>()
            {
                new Car{PetName = "Henry", Color = "Silver", Speed = 100 ,Make = "BMW" },
                new Car{PetName = "Daisy", Color = "Tan", Speed = 95 ,Make = "BMW" },
                new Car{PetName = "Mary", Color = "Black", Speed = 55 ,Make = "VM" },
                new Car{PetName = "Clunker", Color = "Rust", Speed = 5 ,Make = "Yugo" },
                new Car{PetName = "Malvin", Color = "White", Speed = 43 ,Make = "Ford" }
            };

            GetFastCar(cars);
        }

        private static void GetFastCar (List<Car> cars)
        {
            var fastCars = from car in cars
                           where car.Speed > 55
                           select car;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} - {1} is going too fast!", car.PetName, car.Make);
            }
        }

        private static void LinqOverArrayList ()
        {
            Console.WriteLine("\n**** LINQ over ArrayList");

            ArrayList cars = new ArrayList()
            {
                new Car{PetName = "Henry", Color = "Silver", Speed = 100 ,Make = "BMW" },
                new Car{PetName = "Daisy", Color = "Tan", Speed = 95 ,Make = "BMW" },
                new Car{PetName = "Mary", Color = "Black", Speed = 55 ,Make = "VM" },
                new Car{PetName = "Clunker", Color = "Rust", Speed = 5 ,Make = "Yugo" },
                new Car{PetName = "Malvin", Color = "White", Speed = 43 ,Make = "Ford" }
            };

            var carsEnum = cars.OfType<Car>();
            var fastCars = from car in carsEnum where car.Speed > 55 select car;

            if (fastCars != null)
            {
                foreach (var car in fastCars)
                {
                    Console.WriteLine("{0} is going too fast!!!", car.PetName);
                }
            }
        }

        static void LinqProductInfo()
        {
            ProductInfo[] itemsInStock =
            {
                new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo{ Name = "Cheese", Description = "Cheeses", NumberInStock = 120},
                new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100}
            };

            var names = from p in itemsInStock select p.Name;
            var descriptions = from p in itemsInStock select p.Description;
            var longNames = from p in itemsInStock where p.Name.Contains(" ") select p.Name;
            var numberInStockIsSmall = from p in itemsInStock where p.NumberInStock < 50 select p;

            Console.WriteLine("\nNAMES");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nDESCRIPTION");
            foreach (var description in descriptions)
            {
                Console.WriteLine(description);
            }

            Console.WriteLine("\nLONG NAME");
            foreach (var longName in longNames)
            {
                Console.WriteLine(longName);
            }

            Console.WriteLine("\nNUMBER IN SOCK IS SMALL");
            foreach (var number in numberInStockIsSmall)
            {
                Console.WriteLine("Name: " + number.Name + ", number in stock: " + number.NumberInStock);
            }
        }

        static void Query_ByAnonymousMethod()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Daxter", "Skyrim", "Most Wanter 2" };

            Func<string, bool> searchFitlter = delegate (string game) { return game.Contains(" "); };
            Func<string, string> orderByName = delegate (string s) { return s; };

            var subset = currentVideoGames.Where(searchFitlter).OrderBy(orderByName).Select(orderByName);

            if(subset != null)
            {
                foreach (IEnumerable game in subset)
                {
                    Console.WriteLine("Item: {0}", game);
                }
            }

        }

        //--------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------

        private static void ReflectiOverQueryResults (object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet locations: {0}", resultSet.GetType().Assembly.GetName().Name);
            Console.WriteLine();
        }
    }
}