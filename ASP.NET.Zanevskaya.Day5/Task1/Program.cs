using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.LibraryN;
using Task1.Logger;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryBookRepository rep = new BinaryBookRepository("list.bin");
            BookListService s = new BookListService(rep);
            
            s.AddBook(new Book("Author1", "Book1", "Genre1", 24));
            s.AddBook(new Book("Author2", "Book2", "Genre2", 27));
            s.AddBook(new Book("Author3", "Book1", "Genre2", 24));
            s.RemoveBook(new Book("Author3", "Book1", "Genre2", 24));
            s.RemoveBook(new Book("Author3", "Book1", "Genre2", 24));
            Console.WriteLine("Books:");
            PrintBooks(rep.LoadBooks());
        }
            private static void PrintBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        
    }
}
