using System;

namespace CustomException
{
    internal class Radio2
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quite time...");
        }
    }

    internal class Car2
    {
        //----------------------------------------------------------------

        public const int MAX_SPEED = 100;

        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        private bool _carIsDead = false;
        private Radio _theMusicBox = new Radio();

        //----------------------------------------------------------------

        public Car2()
        {
        }

        public Car2(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        //----------------------------------------------------------------

        public void CrankTunes(bool state)
        {
            _theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (delta <= 0)
            {
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");
            }
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
                    CarIsDeadExceptionWithoutMessage ex = new CarIsDeadExceptionWithoutMessage($"{PetName} has overheated!", "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarRus.com";
                    throw ex;
                }
                else
                {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }

        //----------------------------------------------------------------
    }

    /// <summary>
    /// Own exception without overriding Message methods
    /// </summary>
    public class CarIsDeadExceptionWithoutMessage : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadExceptionWithoutMessage()
        {
        }

        public CarIsDeadExceptionWithoutMessage(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }

    /// <summary>
    /// Example of best practices of creating the own exception
    /// </summary>
    public class CarIsDeadExceptionBestPractices : ApplicationException
    {
        public CarIsDeadExceptionBestPractices()
        {
        }

        public CarIsDeadExceptionBestPractices(string message)
            : base(message) { }

        public CarIsDeadExceptionBestPractices(string message, System.Exception inner)
            : base(message, inner) { }

        //----------------------------------------------------------------

        protected CarIsDeadExceptionBestPractices(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    /// <summary>
    /// Class just for code's testing
    /// </summary>
    internal static class TestingOfException2
    {
        public static void TestingOwnOverheatedException2()
        {
            Console.WriteLine("=> Creating a car and stepping on it");
            Car newCar = new Car("Zippy2", 20);
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

        // A multiple exception example
        public static void TestingMultipleException()
        {
            Console.WriteLine("=> Creating a car and stepping on it");
            Car newCar = new Car("Zippy3", 0);
            newCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    newCar.Accelerate(-10);
            }
            catch (CarIsDeadException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErrorTimeStamp);
                Console.WriteLine(ex.CauseOfError);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // A generic catch
        public static void TestingGeneralCatchException()
        {
            Console.WriteLine("*** Handling General Catch Exceptions ***");
            Car2 myCar = new Car2("Rusty", 90);
            try
            {
                myCar.Accelerate(90);
            }
            catch
            {
                Console.WriteLine("Something had happened...");
            }
        }

        // Throw
        public static void TestingJustThrowException()
        {
            Console.WriteLine("*** Handling Just Throw Exceptions ***");
            Car2 myCar = new Car2("RastunThrow", 90);
            try
            {
                myCar.Accelerate(90);
            }
            catch
            {
                throw;
            }
        }

        // Throw Exception
        public static void TestingThrowExException()
        {
            Console.WriteLine("*** Handling Throw Ex Exceptions ***");
            Car2 myCar = new Car2("RastunThrowEx", 90);
            try
            {
                myCar.Accelerate(90);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}