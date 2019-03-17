using System;

namespace OOPExample
{
    internal abstract class Shape
    {
        public string Name { get; set; }

        public Shape()
        {
            Name = "Shape";
        }

        public Shape(string name)
        {
            Name = name;
        }

        public virtual void Draw()
        {
            Console.WriteLine("Drawing {0} the Shape", Name);
        }
    }

    public interface IPointy
    {
        byte Points { get; }

        // ****** ERROR ******

        // Interfaces cannot have data fields
        //public int numbOfPoints;

        // Interfaces cannot have constructors
        //public IPointy() {}

        // Interfaces doesn't support any implementations of members
        //byte GetNumberOfPoints() { return numbOfPoints }
    }

    public interface IDraw3D
    {
        void Draw3D();
    }

    internal class Triangle : Shape, IPointy
    {
        public Triangle()
        {
            Name = "Triangle";
        }

        public Triangle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Triangle", Name);
        }

        public byte Points
        {
            get { return 3; }
        }
    }

    internal class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon()
        {
            Name = "Hexagon";
        }

        public Hexagon(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", Name);
        }

        public void Draw3D()
        {
            Console.WriteLine("Drawing Hexagon in 3D");
        }

        public byte Points
        {
            get { return 6; }
        }
    }

    internal class Circle : Shape
    {
        public Circle()
        {
            Name = "Circle";
        }

        public Circle(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Circle", Name);
        }
    }

    // -- For example of Array of interface type

    internal class Fork : IPointy
    {
        public byte Points => 4;
    }

    internal class PitchFork : IPointy
    {
        public byte Points => 4;
    }

    internal class Knife : IPointy
    {
        public byte Points => 1;
    }

    // -- End of Array of interface Example

    // Interface Name Clash

    public interface IDrawToForm { void Draw(); }

    public interface IDrawToMemory { void Draw(); }

    public interface IDrawToPointer { void Draw(); }

    internal class Octagon : IDrawToForm, IDrawToMemory, IDrawToPointer
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Draw to form");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Draw to memory");
        }

        void IDrawToPointer.Draw()
        {
            Console.WriteLine("Draw to pointer");
        }

        //ERROR! No access modifiers!
        //public void IDrawToPointer.Draw()
        //{
        //    Console.WriteLine("Draw to pointer");
        //}
    }

    public static class InterfaceNameClashTesting
    {
        public static void OctagonMethodImplementationTest()
        {
            Console.WriteLine("**** Fun with Interface Clash Name");
            Octagon octagon = new Octagon();

            // We must use casting to access the Draw() members.
            IDrawToForm itfForm = (IDrawToForm)octagon;
            IDrawToMemory itfMemory = (IDrawToMemory)octagon;
            IDrawToPointer itfPointer = (IDrawToPointer)octagon;

            // Shorthand notation if you don't need
            // the interface variable for later use
            ((IDrawToForm)octagon).Draw();

            // Could also use the 'is' keyword;
            if (octagon is IDrawToMemory dtm)
                dtm.Draw();
        }
    }

    // End Interface Name Clash

    // Interface Hierarchies

    public interface IDrawable { void Draw(); }

    public interface IAdvancedDraw : IDrawable
    {
        void DrawInBoundingBox(int top, int right, int bottom, int left);

        void DrawUpsideDown();
    }

    public class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public void DrawInBoundingBox(int top, int right, int bottom, int left)
        {
            Console.WriteLine("Drawing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawing upside down!");
        }
    }

    // End Interface Hierarchies

    public static class InterfaceTesting
    {
        // Test of containing the shapes in the shape abstract class
        public static void TestShapesContainingOfIShapes()
        {
            Console.WriteLine("**** Fun with Interfaces ****");

            Shape[] shapes =
            {
                new Hexagon(),
                new Circle(),
                new Triangle("Joe"),
                new Circle("Jojo")
            };

            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i].Draw();

                if (shapes[i] is IPointy ip)
                    Console.WriteLine("-> Points: {0}", ip.Points);
                else
                    Console.WriteLine("-> {0}\'s not pointy!", shapes[i].Name);
                Console.WriteLine();
            }
        }

        // Simple method that get a parameter of interface type
        private static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        // Testing Interface as parameter
        public static void TestInterfaceAsParameter()
        {
            Console.WriteLine("**** Fun with Interfaces ****");

            Shape[] shapes =
            {
                new Hexagon(),
                new Circle(),
                new Triangle("Joe"),
                new Circle("Jojo")
            };

            for (int i = 0; i < shapes.Length; i++)
            {
                shapes[i].Draw();

                if (shapes[i] is IPointy ip)
                    Console.WriteLine("-> Points: {0}", ip.Points);
                else
                    Console.WriteLine("-> {0}\'s not pointy!", shapes[i].Name);

                // DrawIn3D interface as parameter
                if (shapes[i] is IDraw3D)
                    DrawIn3D((IDraw3D)shapes[i]);
                else
                    Console.WriteLine("-> Drawing IDraw3D is not compatible type");

                Console.WriteLine();
            }
        }

        // Returns the first object in the array that implements IPointy
        private static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                if (shape is IPointy ip)
                    return ip;
            }
            return null;
        }

        // Testing FindFirstPointyShape method (return interface value)
        public static void TestFindFirstPointyShape()
        {
            Shape[] shapes =
                       {
                new Hexagon(),
                new Circle(),
                new Triangle("Joe"),
                new Circle("Jojo")
            };

            IPointy firstPointyItem = FindFirstPointyShape(shapes);
            Console.WriteLine("The item has {0} points", firstPointyItem.Points);
        }

        // Array IPointy can contain types that implement the IPointy interface.
        public static void TestArrayOfInterface()
        {
            IPointy[] pointyArray =
            {
                new Hexagon(),
                new Fork(),
                new Knife(),
                new PitchFork()
            };

            foreach (IPointy item in pointyArray)
            {
                Console.WriteLine("Object has {0} points.", item.Points);
            }
        }

        // Testing of Interface Hierarchies
        public static void BitMapImageTesting()
        {
            Console.WriteLine("**** Interface Hierarchies fun ****");
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.Draw();
            bitmapImage.DrawInBoundingBox(10, 10, 10, 10);
            bitmapImage.DrawUpsideDown();

            IAdvancedDraw advancedDraw = bitmapImage as IAdvancedDraw;
            if (advancedDraw != null)
                advancedDraw.DrawUpsideDown();
        }
    }
}