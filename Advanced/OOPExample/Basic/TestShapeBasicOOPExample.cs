namespace Advanced
{
    static partial class OOPExample
    {
        /// <summary>
        /// Basic example of OOP with shapes class
        /// </summary>
        private static class TestShape
        {
            public abstract class Shape
            {
                protected double area;

                public abstract double CalcArea();
            }

            public class Circle : Shape
            {
                private readonly double radius;

                public Circle(double radius)
                {
                    this.radius = radius;
                }

                public override double CalcArea()
                {
                    area = 3.14 * (radius * radius);
                    return area;
                }
            }

            public class Recangle : Shape
            {
                private readonly double length, width;

                public Recangle(double length, double width)
                {
                    this.length = length;
                    this.width = width;
                }

                public override double CalcArea()
                {
                    area = length * width;
                    return area;
                }
            }
        }
    }

    /// <summary>
    /// Error! Nonnested types cannot be marked private!
    /// </summary>
    //private class SportCar { }
}