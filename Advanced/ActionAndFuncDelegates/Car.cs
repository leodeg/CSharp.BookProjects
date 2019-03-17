namespace ActionAndFuncDelegates
{
    public class Car
    {
        public delegate void CarEngineHandler(string msgForCaller);

        public CarEngineHandler listOfHandlers;

        public void Accelerate(int delta)
        {
            if (listOfHandlers != null)
            {
                listOfHandlers("Sorry, this car is dead...");
            }
        }
    }
}