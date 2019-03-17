using System;

namespace CarEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //---------------------------------------------------------------------------

            Console.WriteLine("\n---------------- Use Basic Syntax Implementation ----------------\n");

            UseEvents();

            Console.WriteLine("\n---------------- Use Method Conversion ----------------\n");

            UseMethodGroupConversion();

            //---------------------------------------------------------------------------
        }

        //---------------------------------------------------------------------------
        // Use Methods
        //---------------------------------------------------------------------------

        private static void UseEvents()
        {
            Console.WriteLine("*** Fun With Events ***");
            Console.WriteLine();

            Car car1 = new Car("Slug Berry", 100, 10);

            // Register Event handlers.
            car1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            car1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);

            Car.CarEngineHandler delegateExploded = new Car.CarEngineHandler(CarExploded);
            car1.Exploded += delegateExploded;

            Console.WriteLine("**** Speeding Up ****");
            for (int i = 0; i < 6; i++)
            {
                car1.Accelerate(20);
            }

            // Remove CarExploded method from invocation list.
            car1.Exploded -= delegateExploded;

            Console.WriteLine("\n**** Speeding Up ****");
            for (int i = 0; i < 6; i++)
            {
                car1.Accelerate(20);
            }

            Console.WriteLine();
        }

        private static void UseMethodGroupConversion()
        {
            Car c1 = new Car("SlugBug", 100, 10);

            // Register Event
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploded;

            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.Exploded -= CarExploded;

            Console.WriteLine();
            Console.WriteLine("**** Speed Up ****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.WriteLine();
        }

        //---------------------------------------------------------------------------
        // Helper Methods
        //---------------------------------------------------------------------------
        private static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void CarAboutToBlow(string msg)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", msg);
        }

        private static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    /// <summary>
    /// Car class for events examples.
    /// </summary>
    internal class Car
    {
        //---------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string Name { get; set; }

        private bool carIsDead = false;

        //---------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------

        public Car()
        {
        }

        public Car(string name, int maxSpeed, int currentSpeed)
        {
            Name = name;
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
        }

        //---------------------------------------------------------------------------
        // Delegates and Events
        //---------------------------------------------------------------------------

        public delegate void CarEngineHandler(string msg);

        public event CarEngineHandler Exploded;

        public event CarEngineHandler AboutToBlow;

        //---------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                // If Exploded is not equal to null, then invoke msg.
                Exploded?.Invoke("Sorry, this car is dead!");
            }
            else
            {
                CurrentSpeed += delta;

                // Almost dead?
                if (10 == MaxSpeed - CurrentSpeed)
                {
                    AboutToBlow?.Invoke("Careful buddy! Gonna blow");
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }

    public class CarEventArgs : EventArgs
    {
        public readonly string msg;

        public CarEventArgs(string message)
        {
            msg = message;
        }
    }
}