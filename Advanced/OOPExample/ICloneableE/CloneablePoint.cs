using System;

namespace OOPExample.ICloneableE
{
    internal class CloneablePoint
    {
        public static void TestingTwoReferenceToOneObject()
        {
            Point p1 = new Point(50, 50);
            Point p2 = p1;

            p2.X = 0;

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }

        public static void TestingCloneObject()
        {
            // Create an object
            Point p1 = new Point(50, 50);
            // Get a copy of the object
            Point p2 = p1.Clone() as Point;

            // Change the objects value to check if it's changed
            p2.X = 0;

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }

        public static void TestingObjectCloning()
        {
            Point p3 = new Point(100, 100, "Jane");
            Point p4 = p3.Clone() as Point;

            try
            {
                Console.WriteLine("Before Modification: ");
                Console.WriteLine("p3 = {0}", p3);
                Console.WriteLine("p4 = {0}", p4);

                p4.desc.Name = "NewName";
                p4.X = 9;

                Console.WriteLine("After Modification: ");
                Console.WriteLine("p3 = {0}", p3);
                Console.WriteLine("p4 = {0}", p4);
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    internal class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();

        public Point()
        {
        }

        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public Point(int xPos, int yPos, string name)
        {
            X = xPos;
            Y = yPos;
            desc.Name = name;
        }

        // Override Object.ToSting() method
        public override string ToString()
        {
            return $"X = {X}; Y = {Y}; \nName = {desc.Name}; ID = {desc.PointID}\n";
        }

        // Return a copy of the current object.
        public object Clone()
        {
            // First example
            // this.MemberwiseClone();

            // Second Example
            // Get a shallow copy
            Point newPoint = this.MemberwiseClone() as Point;

            // Then fill in the gaps
            PointDescription currentDesc = new PointDescription();
            currentDesc.Name = this.desc.Name;
            newPoint.desc = currentDesc;
            return newPoint;
        }
    }

    internal class PointDescription
    {
        public string Name { get; set; }
        public Guid PointID { get; set; }

        public PointDescription()
        {
            Name = "NoName";
            PointID = Guid.NewGuid();
        }
    }
}