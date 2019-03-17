using System.Collections;

namespace GenericCollections
{
    internal class IntCollection : IEnumerable
    {
        // Create a collection for an Integer values
        private ArrayList arrayOfInteger = new ArrayList();

        // Get an int (perform unboxing)!
        public int GetInt(int position)
        {
            return (int)arrayOfInteger[position];
        }

        // Insert an int (perform boxing)!
        public void AddInt(int value)
        {
            arrayOfInteger.Add(value);
        }

        // Clear Array of Integers
        public void ClearInt()
        {
            arrayOfInteger.Clear();
        }

        public int Count { get { return arrayOfInteger.Count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arrayOfInteger.GetEnumerator();
        }
    }
}