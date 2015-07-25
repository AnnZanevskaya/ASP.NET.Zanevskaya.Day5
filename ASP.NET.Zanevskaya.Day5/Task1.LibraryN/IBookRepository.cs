using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryN
{
    public interface IBookRepository<T>
    {
        IEnumerable<T> LoadBooks();
        void SaveBooks(IEnumerable<T> books);
    }
}
