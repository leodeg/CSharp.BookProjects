using System;

namespace Advanced
{
    internal class AbstractExample
    {
        protected abstract class Shape
        {
            public string Name { get; set; }

            public Shape(string name = "NoName")
            {
                Name = name;
            }

            public abstract void Draw();

            public abstract void DisplayData();
        }

        //------------------------------------------------------------------

        private class Circle : Shape
        {
            public Circle(string name) : base(name)
            {
            }

            public override void DisplayData()
            {
                Console.WriteLine(Name);
            }

            public override void Draw()
            {
                Console.WriteLine("Draw Circle: {0}", Name);
            }
        }

        //------------------------------------------------------------------

        private class Sphere : Circle
        {
            public Sphere(string name) : base(name)
            { }

            public new void Draw()
            {
                Console.WriteLine("Draw Sphere");
            }
        }

        //------------------------------------------------------------------

        private class Hexagon : Shape
        {
            public Hexagon(string name) : base(name)
            {
            }

            public override void DisplayData()
            {
                Console.WriteLine(Name);
            }

            public override void Draw()
            {
                Console.WriteLine("Draw Hexagon: {0}", Name);
            }
        }

        //------------------------------------------------------------------

        public static class TestingShape
        {
            public static void TestingInheritanceAbstractMethods()
            {
                Circle circle = new Circle("Circle");
                circle.DisplayData();
                circle.Draw();

                Console.WriteLine("**************");

                Hexagon hexagon = new Hexagon("Hexagon");
                hexagon.DisplayData();
                hexagon.Draw();

                Console.WriteLine("**************");

                Shape[] shapes = {
                    new Hexagon("h1"),
                    new Circle("c1"),
                    new Hexagon("h2"),
                    new Circle("c2") };

                foreach (var shape in shapes)
                {
                    shape.Draw();
                    shape.DisplayData();
                    Console.WriteLine("***");
                }
            }

            public static void TestingShadowingAbstractMethods()
            {
                Sphere sphere = new Sphere("SphereInheritance");
                Console.Write("Self implementation \t || \t");
                // This call the self implementation
                sphere.Draw();

                Console.Write("Implementation of parent's method \t || \t");
                // This call the parent's method implementation
                ((Circle)sphere).Draw();
            }
        }
    }
}