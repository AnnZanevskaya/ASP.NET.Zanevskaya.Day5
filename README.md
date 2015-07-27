# ASP.NET.Zanevskaya.Day5

Task1

Разработать класс Book:

public class Book : IEquatable<Book>, IComparable<Book>
{
    public string Author { get; set; }
    public string Title { get; set; }
    //+ два-три нужных и стандартных для книги свойств
    //TODO 
}

переопределив для него необходимые методы класса Object 
(посмотреть рекомендации по переопределению GetHashCode 
http://blogs.msdn.com/b/ruericlippert/archive/2011/03/20/guidelines-and-rules-for-gethashcode.aspx) и методы интерфейсов.

Для выполнения основных операций со списком книг, которые хранятся в некотором хранилище 
(сегодня это двоичный файл, но будут и другие хранилища :) ) разработать класс BookListService 
(как сервис для работы со списком книг) с функциональностью

AddBook (добавить книгу в хранилище в случае, если такой книги нет, 
в противном случае выбросить исключение и залогировать его);
RemoveBook (удалить книгу, если она есть, в противном случае выбросить исключение и залогировать его);
FindByTag (найти книгу по заданному критерию);
SortBooksByTag (отсортировать список книг по заданному критерию).

Для логирования исключений использовать фреймворк NLog или Lof4Net.

Работу классов продемонстрировать на примере консольного приложения.
