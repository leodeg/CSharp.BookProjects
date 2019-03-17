namespace OOPExample
{
    internal class InheritanceIsAExample
    {
        /// <summary>
        /// Example for inheritance "is-a"
        /// </summary>
        public class CarInheritanceExample
        {
            public readonly int maxSpeed;
            private int _currentSpeed;

            public CarInheritanceExample()
            {
                maxSpeed = 55;
            }

            public CarInheritanceExample(int max)
            {
                maxSpeed = max;
            }

            public int Speed
            {
                get { return _currentSpeed; }
                set
                {
                    _currentSpeed = value;
                    if (_currentSpeed > maxSpeed)
                        _currentSpeed = maxSpeed;
                }
            }
        }

        public class MiniVan : CarInheritanceExample
        {
            public MiniVan() : base()
            {
            }

            public MiniVan(int max) : base(max)
            {
            }
        }
    }
}