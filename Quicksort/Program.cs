using System;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 5, 0, 34, 3, 9 };
            var letters = new[] { 'f', 'g', 'a', 'm', 'o' };
            var names = new[] { "Peter", "Alex", "John", "Fred" };
            var books = new[] { new Book("4ds"), new Book("2er"), new Book("31") };

            // Quicksort
            SortArray(numbers);
            SortArray(letters);
            SortArray(names);
            SortArray(books);
            //

            PrintArray(numbers);
            PrintArray(letters);
            PrintArray(names);
            PrintArray(books);

            Console.WriteLine("\nPress any key to stop execution.");
            Console.ReadKey();
        }

        public static void PrintArray<T>(T[] array)
        {
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }

        private static void SortArray<T>(T[] array) where T : IComparable<T>
        {
            Quicksort(array, 0, array.Length - 1);
        }

        private static void Quicksort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            int i = left;
            int j = right;

            var pivot = array[left + (right - left) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                    i++;

                while (array[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
                Quicksort(array, left, j);

            if (i < right)
                Quicksort(array, i, right);
        }
    }

    class Book : IComparable<Book>
    {
        public string ISBN { get; set; }

        public Book(string isbn)
        {
            ISBN = isbn;
        }

        public int CompareTo(Book other)
        {
            return ISBN.CompareTo(other.ISBN);
        }

        public override string ToString()
        {
            return ISBN;
        }
    }
}
