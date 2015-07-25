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
            {
                Exception e = new ArgumentNullException("repository is invalid(null)");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            } 
            this.repository = repository;
        }
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e = new ArgumentNullException("book is invalid(null)");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            }
            if (BookExistence(book))
            {
                Exception e = new ArgumentNullException("book already in repository");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            }
            books.Add(book);
            repository.SaveBooks(books);
            logger.Info(String.Format("add new book {0}", book));
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e = new ArgumentNullException("book is invalid(null)");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            }
            if (!BookExistence(book))
            {
                Exception e = new ArgumentNullException("book doesn't exist");
                logger.Info(e.Message);
                logger.Error(e.StackTrace);
                throw e;
            }
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
            if (comparer == null) throw new ArgumentNullException("comparer");
            books = repository.LoadBooks().ToList();
            books.Sort(comparer);
            repository.SaveBooks(books);           
        }
        private bool BookExistence(Book book)
        {
            Book existBook = books.FirstOrDefault(x => x.Equals(book));
            if (ReferenceEquals(existBook, null)) return false;
            return true;

        }
    }
}
