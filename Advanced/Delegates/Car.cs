using System;

namespace Delegates
{
    public class Car
    {
        //------------------------------------------------------------------------------
        // Data
        //------------------------------------------------------------------------------

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string Name { get; set; }

        // Is the car alive or dead?
        private bool carIsDead;

        //------------------------------------------------------------------------------
        // Constructors
        //------------------------------------------------------------------------------

        public Car()
        {
        }

        public Car(string name, int maxSpeed, int currSpeed)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            CurrentSpeed = currSpeed;
        }

        //------------------------------------------------------------------------------
        // Define Delegate
        //------------------------------------------------------------------------------

        // 1. Define a delegate type.
        public delegate void CarEngineHandler(string messageForCaller);

        // 2. Define a member variable of this delegate
        private CarEngineHandler listOfHandlers;

        // 3. Add registration function for the caller
        // 'Delegate.Combine()' method is the same as '+=' operator
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (methodToCall != null)
            {
                if (listOfHandlers == null)
                    listOfHandlers = methodToCall;
                else
                    listOfHandlers = Delegate.Combine(listOfHandlers, methodToCall) as CarEngineHandler;
            }
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            if (methodToCall != null)
            {
                listOfHandlers -= methodToCall;
            }
        }

        //------------------------------------------------------------------------------
        // Define Accelerate() method
        //------------------------------------------------------------------------------

        // 4. Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                listOfHandlers?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;

                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
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
}