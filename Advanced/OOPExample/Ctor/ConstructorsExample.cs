using System;

namespace OOPExample
{
    internal class ConstructorsExample
    {
        /// <summary>
        /// Enum example for constructors
        /// </summary>
        public enum PointColor { LightBlue, BloodRed, Gold, Red, Green, Yellow, SuperYellow }

        /// <summary>
        /// Constructors example
        /// </summary>
        public class Point2
        {
            //------------------------------------------------------------------

            public int X { get; set; }
            public int Y { get; set; }
            public PointColor Color { get; set; }

            //------------------------------------------------------------------

            public Point2(int xVal, int yVal)
            {
                X = xVal;
                Y = yVal;
                Color = PointColor.Gold;
            }

            public Point2(PointColor ptColor)
            {
                Color = ptColor;
            }

            public Point2()
                : this(PointColor.BloodRed) { }

            //------------------------------------------------------------------

            public void DisplayStats()
            {
                Console.WriteLine("[{0}, {1}]", X, Y);
                Console.WriteLine("Point is {0}", Color);
            }

            public static void Testing()
            {
                Point2 goldPoint = new Point2(PointColor.Gold) { X = 90, Y = 20 };
                goldPoint.DisplayStats();
                Console.WriteLine();

                Point2 standartPoint = new Point2() { X = 90, Y = 20 };
                standartPoint.DisplayStats();
                Console.WriteLine();

                Point2 standartPoint2 = new Point2 { Color = PointColor.LightBlue, X = 20, Y = 30 };
                standartPoint2.DisplayStats();
                Console.WriteLine();

                Point2 standartPoint3 = new Point2(20, 35) { Color = PointColor.Gold };
                standartPoint3.DisplayStats();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Read-only example
        /// </summary>
        public class ReadonlyExample
        {
            // Read-only fields can be assigned in ctors,
            // but nowhere else
            public readonly double PI;

            public ReadonlyExample()
            {
                PI = 3.14;
            }
        }

        /// <summary>
        /// Пример Конструктора
        /// Используем перегрузку конструктора ссылаясь на основной конструктор при
        /// помощи ключевого слова this (которое указывает на самый полный
        /// конструктор данного класса)
        /// </summary>
        public class Motorcycle
        {
            public int driverIntensity;
            public string driverName;

            //------------------------------------------------------------------

            public Motorcycle()
            {
            }

            public Motorcycle(int intensity)
                : this("", intensity) { }

            public Motorcycle(string name)
                : this(name, 0) { }

            public Motorcycle(string name, int intensity)
            {
                if (intensity > 10)
                    intensity = 10;
                if (intensity < 1)
                    intensity = 1;
                driverIntensity = intensity;
                driverName = name;
            }

            //------------------------------------------------------------------
        }

        // Элементы объявленные в пространстве имен нельзя объявлять как private
        // Но вложенные, объявленные внутри класса - можно

        /// <summary>
        /// OK! Nested Types can be marked private
        /// </summary>
        public class SportsCar
        {
            private enum Color { Red, Green, Blue }
        }
    }
}