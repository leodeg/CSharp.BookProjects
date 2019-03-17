using System;

namespace Advanced
{
    /// <summary>
    /// Example of reference types
    /// </summary>
    public class PointRef
    {
        private int X, Y;

        public PointRef()
        {
            X = 0;
            Y = 0;
        }

        public PointRef(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
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
            Console.WriteLine("xPos = {0}, yPos = {1}", X, Y);
        }

        public override string ToString()
        {
            return $"xPos = {X}, yPos = {Y}";
        }
    }
}