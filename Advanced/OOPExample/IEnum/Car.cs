using System;
using System.Collections;

namespace OOPExample.IEnum
{
    internal class Radio
    {
        /// <summary>
        /// Turn ON/OFF the radio
        /// </summary>
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quite time...");
        }
    }

    internal class Car
    {
        public const int MAX_SPEED = 100;

        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        private bool _carIsDead = false;
        private Radio _theMusicBox = new Radio();

        public Car()
        {
        }

        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public void CrankTunes(bool state)
        {
            _theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (_carIsDead)
            {
                Console.WriteLine("{0} is out of order...", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MAX_SPEED)
                {
                    _carIsDead = true;
                    CurrentSpeed = 0;

                    throw new System.Exception($"{PetName} has overheated");
                }
                else
                {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }

    /// <summary>
    /// Contains a set of Car objects.
    /// </summary>
    internal class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("R", 30);
            carArray[1] = new Car("T", 20);
            carArray[2] = new Car("D", 34);
            carArray[3] = new Car("S", 50);
        }

        public IEnumerator GetEnumerator()
        {
            // **** First example ****

            //foreach (Car car in carArray)
            //{
            //    yield return car;
            //};

            // **** Second example ****

            // Without foreach you can also use this implementation
            //yield return carArray[0];
            //yield return carArray[1];
            //yield return carArray[2];
            //yield return carArray[3];

            // **** Third example ****

            // This will get thrown immediately
            //throw new System.Exception("This will get called");

            return actualImplementation();
            // This is a private function
            IEnumerator actualImplementation()
            {
                foreach (Car car in carArray)
                {
                    yield return car;
                }
            }
        }

        public IEnumerable GetTheCars(bool returnReversed)
        {
            // do some error checking here.
            return actualImplementation();
            IEnumerable actualImplementation()
            {
                if (returnReversed)
                {
                    for (int i = carArray.Length; i != 0; i--)
                    {
                        yield return carArray[i - 1];
                    }
                }
                else
                {
                    // Return the items as placed in the array.
                    foreach (Car car in carArray)
                    {
                        yield return car;
                    }
                }
            }
        }
    }

    internal static class TestingEnumerator
    {
        public static void WorkWithEnumerator()
        {
            Garage carlot = new Garage();

            IEnumerator i = carlot.GetEnumerator();

            i.MoveNext();
            Car newCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", newCar.PetName, newCar.CurrentSpeed);

            i.MoveNext();
            newCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", newCar.PetName, newCar.CurrentSpeed);

            i.MoveNext();
            newCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", newCar.PetName, newCar.CurrentSpeed);

            i.MoveNext();
            newCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", newCar.PetName, newCar.CurrentSpeed);
        }

        public static void WorkWithIEnumerableMethod()
        {
            Garage carlot = new Garage();

            // Get items using GetEnumerator
            foreach (Car car in carlot)
            {
                Console.WriteLine("{0} is going {1} MPH", car.PetName, car.CurrentSpeed);
            }

            Console.WriteLine();
            Console.WriteLine("Get Items in reverse using named iterator");

            // Get items (in reverse!) using named iterator.
            foreach (Car car in carlot.GetTheCars(true))
            {
                Console.WriteLine("{0} is going {1} MPH", car.PetName, car.CurrentSpeed);
            }
        }
    }
}