using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.LibraryN
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        private string author;
        private string title;
        private string genre;
        private int year;

        public string Author
        {
            get { return author; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("author");
                else author = value;
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("title");
                else title = value;
            }
        }
        public string Genre
        {
            get { return genre; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("genre");
                else genre = value;
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                else year = value;
            }
        }
        public Book() : this("Title don't set", "Author don't set", "Description don't set", 0) { }
        public Book(string author, string title, string genre, int year)
        {
            Author = author;
            Title = title;
            Genre = genre;
            Year = year;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (String.Compare(this.Author, other.Author, true) != 0 || String.Compare(this.Title, other.Title, true) != 0 ||
                String.Compare(this.Genre, other.Genre, true) != 0 || !(this.Year == other.Year))
                return false;
            return true;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null)) return 1;
            if (this.Equals(other)) return 0;

            return String.Compare(Title, other.Title, true);
        }

        public override int GetHashCode()
        {
            int hashCode = Author.GetHashCode() * 31;
            hashCode += Title.GetHashCode() * 31;
            hashCode += Genre.GetHashCode() * 31;
            hashCode += Year.GetHashCode() * 31;
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;

            Book book = obj as Book;
            return Equals(book);
        }
        public override string ToString()
        {
            return String.Format("Title: {0} Author: {1} Genre: {2} Year: {3}",
                Title, Author, Genre, Year);
        }
    }
}
