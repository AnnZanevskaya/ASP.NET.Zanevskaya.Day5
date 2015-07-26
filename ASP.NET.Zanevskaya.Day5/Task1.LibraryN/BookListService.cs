using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Logger;


namespace Task1.LibraryN
{
    public class BookListService
    {
        private ILogger logger = new NLogAdapter();
        private IBookRepository<Book> repository;
        private List<Book> books = new List<Book>();

        public BookListService(IBookRepository<Book> repository)
        {
            if (ReferenceEquals(repository, null))
                LoggerMessager(new ArgumentNullException("repository is invalid(null)"));
            this.repository = repository;
        }
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                LoggerMessager(new ArgumentNullException("book is invalid(null)"));
            if (BookExistence(book))
                LoggerMessager(new ArgumentNullException("book already in repository"));
            books.Add(book);
            repository.SaveBooks(books);
            logger.Info(String.Format("add new book {0}", book));
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                LoggerMessager(new ArgumentNullException("book is invalid(null)"));
            if (!BookExistence(book))
                LoggerMessager(new ArgumentNullException("book doesn't exist"));
            books.Remove(book);
            repository.SaveBooks(books);
            logger.Info(String.Format("remove book {0}", book));
        }
        public IEnumerable<Book> GetBooks()
        {
            return repository.LoadBooks();
        }
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (ReferenceEquals(comparer, null))
                LoggerMessager(new ArgumentNullException("comparer is invalid(null)"));
            books = repository.LoadBooks().ToList();
            books.Sort(comparer);
            repository.SaveBooks(books);
        }
        public Book FindByTag(Func<Book, bool> func)
        {
            if (ReferenceEquals(func, null))
                LoggerMessager(new ArgumentNullException("func is invalid(null)"));
            Book findBook = null;
            books = repository.LoadBooks().ToList();
            findBook = books.FirstOrDefault(func);
            return findBook;
        }
        private bool BookExistence(Book book)
        {
           Book existBook = books.FirstOrDefault(x => x.Equals(book));
           if (ReferenceEquals(existBook, null)) return false;
           return true;
        }
        private void LoggerMessager(Exception e)
        {
            logger.Info(e.Message);
            logger.Error(e.StackTrace);
            throw e;
        }
    }
}
