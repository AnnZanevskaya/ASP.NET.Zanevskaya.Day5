using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1.LibraryN
{
    public class BinaryBookRepository: IBookRepository<Book>
    {
        private readonly string filePath;
        public BinaryBookRepository()
        {
          string folderPath = AppDomain.CurrentDomain.BaseDirectory;
          filePath = Path.Combine(folderPath, "books");
        }
        public BinaryBookRepository(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException();
            this.filePath = filePath;
        }

        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(filePath)) throw new FileNotFoundException("filePath didn't found");
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(stream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Book book = new Book();
                    book.Title = reader.ReadString();
                    book.Author = reader.ReadString();
                    book.Genre = reader.ReadString();
                    book.Year = reader.ReadInt32();
                    books.Add(book);
                }
            }
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null) throw new ArgumentNullException();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Genre);
                    writer.Write(book.Year);
                }
            }
        }
    }
}
