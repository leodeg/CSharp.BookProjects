using System;

namespace CustomException
{
    /// <summary>
    /// Radio for a Car
    /// </summary>
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

    /// <summary>
    /// Overriding example class
    /// </summary>
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

                    // Create a new Exception
                    CarIsDeadException ex = new CarIsDeadException($"{PetName} has overheated!", "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarRus.com";
                    throw ex;
                }
                else
                {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }

    /// <summary>
    /// Own exception for Car class
    /// </summary>
    public class CarIsDeadException : ApplicationException
    {
        private readonly string _messageDetails = String.Empty;

        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException()
        {
        }

        public CarIsDeadException(string message, string cause, DateTime time)
        {
            _messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        public override string Message => $"Car Error Message: {_messageDetails}";
    }

    /// <summary>
    /// Class just for code's testing
    /// </summary>
    internal static class TestingOfException
    {
        public static void TestingOwnOverheatedExption()
        {
            Console.WriteLine("=> Creating a car and stepping on it");
            Car newCar = new Car("Zippy", 20);
            newCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    newCar.Accelerate(10);
            }
            catch (CarIsDeadException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErrorTimeStamp);
                Console.WriteLine(ex.CauseOfError);
            }
        }
    }
}