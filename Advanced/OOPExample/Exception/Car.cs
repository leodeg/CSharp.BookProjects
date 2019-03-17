using System;

namespace OOPExample.Exception
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

    internal static class TestingException
    {
        public static void TestingOverheated()
        {
            Console.WriteLine("=> Creating a car and stepping on it");
            Car newCar = new Car("Zippy", 20);
            newCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    newCar.Accelerate(10);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("\n*** ERROR! ***");
                Console.WriteLine("Method: {0}", ex.TargetSite);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source: {0}", ex.Source);
                Console.WriteLine("Class defining method: {0}", ex.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine("Exception Stack trace: {0}", ex.StackTrace);
            }
        }
    }
}