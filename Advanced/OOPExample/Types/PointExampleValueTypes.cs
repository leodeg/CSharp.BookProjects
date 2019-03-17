using System;

namespace Advanced
{
    /// <summary>
    /// Example of value types
    /// </summary>
    public struct Point
    {
        private int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetX() => X;

        public int GetY() => Y;

        public void Increment()
        {
            X++;
            Y++;
        }

        public void Decrement()
        {
            X--;
            Y--;
        }

        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }

        // Deconstructing Tuples
        public (int xPos, int yPos) Deconstruct() => (X, Y);
    }
}