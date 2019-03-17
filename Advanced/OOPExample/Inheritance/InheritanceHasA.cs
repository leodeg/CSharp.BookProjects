using System;

namespace OOPExample
{
    internal class InheritanceHasA
    {
        /// <summary>
        /// Simple class for example of inheritance of type "has-a"
        /// </summary>
        public class Radio
        {
            private bool _isTurnOn = false;

            public Radio()
            {
            }

            public void Power(bool onOff)
            {
                _isTurnOn = onOff;
            }
        }

        /// <summary>
        /// Example of inheritance of type "has-a"
        /// </summary>
        public class Car
        {
            private Radio _myRadio = new Radio();

            public void TurnOnRadio(bool onOff)
            {
                _myRadio.Power(onOff);
            }
        }

        public class Shape
        {
            public void Draw()
            {
                Console.WriteLine("Draw shape");
            }
        }

        public class Circle : Shape
        {
            public new void Draw()
            {
                Console.WriteLine("Draw circle");
            }
        }

        public class Hexagon : Shape
        {
            public new void Draw()
            {
                Console.WriteLine("Draw hexagon");
            }
        }

        /// <summary>
        /// Inheritance testing
        /// </summary>
        public static class ShapeTesting
        {
            public static void Testing()
            {
                Shape[] shape = new Shape[3];
                shape[0] = new Circle();
                shape[1] = new Hexagon();
                shape[2] = new Circle();

                // Обращаясь к объектам через базовый класс,
                // будет вызвана функция базового класса

                shape[0].Draw();
                shape[1].Draw();
                shape[2].Draw();

                // Output
                // Draw shape
                // Draw shape
                // Draw shape

                // Обращаясь к объекту непосредственно напрямую через их класс, будет
                // вызвана функция в классе которая перекрывает базовую функцию при
                // помощи ключевого слова "new"

                Hexagon hexagon = new Hexagon();
                Circle circle = new Circle();

                hexagon.Draw();
                circle.Draw();

                // Output
                // Draw hexagon
                // Draw circle
            }
        }
    }
}