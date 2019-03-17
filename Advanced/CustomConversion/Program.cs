using System;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CustomConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DisplayDarkYellow("\n----------------------------------");
            DisplayDarkYellow("\\\\ Overload Conversion Operators");
            DisplayDarkYellow("----------------------------------\n");

            UseConversion();

            DisplayDarkYellow("\n----------------------------------");
            DisplayDarkYellow("\\\\ Convert to integer");
            DisplayDarkYellow("----------------------------------\n");

            UseConversionToInteger();

            DisplayDarkYellow("\n----------------------------------");
            DisplayDarkYellow("\\\\ Implicit Conversion");
            DisplayDarkYellow("----------------------------------\n");

            UseConversionSquareToRectangle();

            Console.WriteLine();
        }

        private static void DisplayDarkYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        private static void UseConversion()
        {
            Rectangle rectangle = new Rectangle(15, 4);
            DisplayDarkYellow("----------------------------------");
            DisplayDarkYellow("\\\\ Draw Rectangle");
            DisplayDarkYellow("----------------------------------");
            Console.WriteLine(rectangle.ToString());
            rectangle.Draw();

            Square square = (Square)rectangle;
            DisplayDarkYellow("----------------------------------");
            DisplayDarkYellow("\\\\ Draw Square");
            DisplayDarkYellow("----------------------------------");
            Console.WriteLine(square.ToString());
            square.Draw();

            DisplayDarkYellow("----------------------------------");
            DisplayDarkYellow("\\\\ Rectangle draw Square");
            DisplayDarkYellow("----------------------------------");
            rectangle.DrawSquare(new Square(5));
        }

        private static void UseConversionToInteger()
        {
            // Conversion from integer to Square
            Square square = (Square)10;
            DisplayDarkYellow("\\\\ Conversion from integer to Square");
            Console.WriteLine("square = {0}", square);

            // Conversion from Square to integer
            int sideLength = (int)square;
            DisplayDarkYellow("\\\\ Conversion from Square to integer");
            Console.WriteLine("Side length of square = {0}", sideLength);
        }

        private static void UseConversionSquareToRectangle()
        {
            Square square = new Square(5);
            DisplayDarkYellow("----------------------------------");
            DisplayDarkYellow("\\\\ Create a Square");
            DisplayDarkYellow("----------------------------------");
            Console.WriteLine("square = {0}", square);

            Rectangle rectangle = square;
            DisplayDarkYellow("----------------------------------");
            DisplayDarkYellow("\\\\ => Convert Square to Rectangle");
            DisplayDarkYellow("----------------------------------");
            Console.WriteLine("rectangle = {0}", rectangle);
        }
    }

    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height) : this()
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public void DrawSquare(Square square)
        {
            Console.WriteLine(square.ToString());
            square.Draw();
        }

        public override string ToString() => $"[Width = {Width}; Height = {Height}]";

        public static implicit operator Rectangle(Square square)
        {
            return new Rectangle
            {
                Height = square.Length,
                Width = square.Length * 2
            };
        }
    }

    public struct Square
    {
        public int Length { get; set; }

        public Square(int length) : this()
        {
            Length = length;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Length = {Length}]";

        //----------------
        // Override conversion operators
        //----------------
        // public static explicit operator wanted_type(base_type baseType) {return some_value;}
        // public static implicit operator wanted_type(base_type baseType) {return some_value;}

        public static explicit operator Square(Rectangle rectangle) => new Square { Length = rectangle.Height };

        public static explicit operator Square(int sideLenth) => new Square { Length = sideLenth };

        public static explicit operator int(Square square) => square.Length;
    }
}