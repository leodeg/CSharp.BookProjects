using System;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace OverloadedOps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DisplayDarkYellow("--------------------------------");
            DisplayDarkYellow("\\\\ Basic Operations");
            DisplayDarkYellow("--------------------------------\n");

            UseOverloadedOperators();

            DisplayDarkYellow("\n--------------------------------");
            DisplayDarkYellow("\\\\ Short Operators");
            DisplayDarkYellow("--------------------------------\n");

            UseShortOperators();

            DisplayDarkYellow("\n--------------------------------");
            DisplayDarkYellow("\\\\ Increment and Decrement Operators");
            DisplayDarkYellow("--------------------------------\n");

            UseIncrAndDecrOperators();

            DisplayDarkYellow("\n--------------------------------");
            DisplayDarkYellow("\\\\ Equality Operators");
            DisplayDarkYellow("--------------------------------\n");

            UseEqualityOperators();

            DisplayDarkYellow("\n--------------------------------");
            DisplayDarkYellow("\\\\ Comparable Operators");
            DisplayDarkYellow("--------------------------------\n");

            UseComparableOperators();

            Console.WriteLine();
        }

        private static void DisplayDarkYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        private static void UseOverloadedOperators()
        {
            // Make two points
            Point point1 = new Point(10f, 20f);
            Point point2 = new Point(30f, 40f);
            Console.WriteLine("point one: {0}", point1);
            Console.WriteLine("point two: {0}", point2);

            // Add the points to make a bigger point.
            Console.WriteLine("{0} + {1} = {2}", point1, point2, point1 + point2);
            // Subtract the points to make a smaller point.
            Console.WriteLine("{0} - {1} = {2}", point1, point2, point1 - point2);
            // Multiple the points to make a bigger point.
            Console.WriteLine("{0} * {1} = {2}", point1, point2, point1 * point2);
            // Divide the points to make a smaller point.
            Console.WriteLine("{0} / {1} = {2}", point1, point2, point1 / point2);
        }

        private static void UseShortOperators()
        {
            Point point1 = new Point(30f, 50f);
            Point point2 = new Point(20f, 40f);
            Console.WriteLine("point one: {0}", point1);
            Console.WriteLine("point two: {0}", point2);

            // (+=) and (-=) overloaded operators
            Console.WriteLine("{0} += {1} = {2}", point1, point2, point1 += point2);
            Console.WriteLine("{0} -= {1} = {2}", point1, point2, point1 -= point2);
        }

        private static void UseIncrAndDecrOperators()
        {
            Point point = new Point(1f, 1f);
            Console.WriteLine("point: {0}", point);

            // Increment and Decrement overloaded operators
            Console.WriteLine("{0}++ = {1}", point, ++point);
            Console.WriteLine("{0}-- = {1}", point, --point);
        }

        private static void UseEqualityOperators()
        {
            Point point1 = new Point(20f, 30f);
            Point point2 = new Point(20f, 30f);

            Console.WriteLine("{0} == {1} = {2}", point1, point2, point1 == point2);
            Console.WriteLine("{0} == {1} = {2}", point1, point2, point1 != point2);
        }

        private static void UseComparableOperators()
        {
            Point point1 = new Point(20f, 30f);
            Point point2 = new Point(20f, 30f);

            Console.WriteLine("{0} > {1} = {2}", point1, point2, point1 > point2);
            Console.WriteLine("{0} < {1} = {2}", point1, point2, point1 < point2);
            Console.WriteLine("{0} >= {1} = {2}", point1, point2, point1 >= point2);
            Console.WriteLine("{0} <= {1} = {2}", point1, point2, point1 <= point2);

            DisplayDarkYellow("\n--------------------------------\n");

            Point point3 = new Point(26f, 50f);
            Point point4 = new Point(36f, 30f);

            Console.WriteLine("{0} > {1} = {2}", point3, point4, point3 > point4);
            Console.WriteLine("{0} < {1} = {2}", point3, point4, point3 < point4);
            Console.WriteLine("{0} >= {1} = {2}", point3, point4, point3 >= point4);
            Console.WriteLine("{0} <= {1} = {2}", point3, point4, point3 <= point4);

            DisplayDarkYellow("\n--------------------------------\n");

            Point point5 = new Point(50f, 50f);
            Point point6 = new Point(36f, 30f);

            Console.WriteLine("{0} > {1} = {2}", point5, point6, point5 > point6);
            Console.WriteLine("{0} < {1} = {2}", point5, point6, point5 < point6);
            Console.WriteLine("{0} >= {1} = {2}", point5, point6, point5 >= point6);
            Console.WriteLine("{0} <= {1} = {2}", point5, point6, point5 <= point6);
        }
    }

    internal class Point : IComparable<Point>
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"[X = {this.X}; Y = {this.Y}]";

        //-----------------------------------------------------------------------------------
        // Overload the basic arithmetic operators
        //-----------------------------------------------------------------------------------

        //------------------------
        // Overload with the same type
        //------------------------

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator *(Point p1, Point p2) => new Point(p1.X * p2.X, p1.Y * p2.Y);

        public static Point operator /(Point p1, Point p2) => new Point(p1.X / p2.X, p1.Y / p2.Y);

        //------------------------
        // Overload with another type
        //------------------------

        public static Point operator *(Point p1, int change) => new Point(p1.X * change, p1.Y * change);

        public static Point operator -(Point p1, int change) => new Point(p1.X - change, p1.Y - change);

        public static Point operator +(Point p1, int change) => new Point(p1.X + change, p1.Y + change);

        public static Point operator /(Point p1, int change) => new Point(p1.X / change, p1.Y / change);

        //------------------------
        // Overload with increment and decrement operators
        //------------------------

        public static Point operator ++(Point p1) => new Point(p1.X + 1, p1.Y + 1);

        public static Point operator --(Point p1) => new Point(p1.X - 1, p1.Y - 1);

        //------------------------
        // Overload equality Operators
        //------------------------

        public override bool Equals(object obj) => obj.ToString() == this.ToString();

        public override int GetHashCode() => this.ToString().GetHashCode();

        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);

        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

        //------------------------
        // Overload comparable operators
        //------------------------

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
                return 1;
            if (this.X < other.X && this.Y < other.Y)
                return -1;
            else
                return 0;
        }

        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;

        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;

        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;

        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;
    }
}