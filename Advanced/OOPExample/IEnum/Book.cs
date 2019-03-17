using System;
using System.Collections;

namespace OOPExample.IEnum
{
    /// <summary>
    /// The basic book class
    /// </summary>
    internal class Book
    {
        public string Name { get; set; }
        public int Pages { get; set; }

        public Book() : this("NoName", 0)
        {
        }

        public Book(string name) : this(name, 0)
        {
        }

        public Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
        }
    }

    /// <summary>
    /// Library of Books
    /// </summary>
    internal class Library : IEnumerable
    {
        private readonly Book[] _books;

        public Library(Book[] bookList)
        {
            // Specify the size of the books array
            _books = new Book[bookList.Length];

            // Copy elements from bookList to _books
            for (int i = 0; i < bookList.Length; i++)
            {
                _books[i] = bookList[i];
            }
        }

        // This is default IEnumerator that point at LibraryEnum GetEnumerator()
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public LibraryEnum GetEnumerator()
        {
            return new LibraryEnum(_books);
        }
    }

    /// <summary>
    ///Library Enumerator Implementation
    /// </summary>
    internal class LibraryEnum : IEnumerator
    {
        private Book[] _books;          // Array of Books
        private int _position = -1;     // Position of the array

        // Basic constructor
        // Get the array of books
        public LibraryEnum(Book[] bookList)
        {
            _books = bookList;
        }

        // Implementation of Basic Current position
        object IEnumerator.Current => Current;

        // Try get current position of the array
        public Book Current
        {
            get
            {
                // Try get current books
                try
                {
                    return _books[_position];
                }
                // Or catch exception
                catch (System.Exception)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        // Get next position of library
        public bool MoveNext()
        {
            _position++;
            return (_position < _books.Length);
        }

        // Reset position to -1 (before first element of the array)
        public void Reset()
        {
            _position = -1;
        }
    }

    /// <summary>
    /// Testing the Book Library Enumerator Implementation
    /// </summary>
    internal static class BookEnumTest
    {
        public static void BookEnumeratorTesting()
        {
            Book[] books =
            {
                new Book("Rheno Deckart", 256),
                new Book("John Support", 356),
                new Book("For Futher", 226)
            };

            Library booksLibrary = new Library(books);
            foreach (var book in booksLibrary)
            {
                Console.WriteLine("Book: {0}, Pages: {1}", book.Name, book.Pages);
            }
        }
    }
}