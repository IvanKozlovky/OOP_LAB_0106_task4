using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Author { get; }
    public string Title { get; }
    public int Year { get; }
    public string Group { get; }

    public Book(string author, string title, int year, string group)
    {
        Author = author;
        Title = title;
        Year = year;
        Group = group;
    }
}

class BookCollections
{
    private List<List<Book>> _collections;

    public BookCollections()
    {
        _collections = new List<List<Book>>();
    }

    public void AddCollection(List<Book> collection)
    {
        _collections.Add(collection);
    }

    public List<Book> this[int index]
    {
        get { return _collections[index]; }
        set { _collections[index] = value; }
    }

    public int CollectionsCount
    {
        get { return _collections.Count; }
    }

    public int CountCollectionsWithSize(int size)
    {
        return _collections.Count(c => c.Count == size);
    }

    public List<Book> GetMaxCollection()
    {
        return _collections.OrderByDescending(c => c.Count).FirstOrDefault();
    }

    public List<Book> GetMinCollection()
    {
        return _collections.OrderBy(c => c.Count).FirstOrDefault();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Book> collection1 = new List<Book>
        {
            new Book("Сенкевич", "Потоп", 1978, "Х"),
            new Book("Ландау", "Механика", 1989, "У")
        };

        List<Book> collection2 = new List<Book>
        {
            new Book("Оруелл", "1984", 1949, "Р"),
            new Book("Толкін", "Володар перснів", 1954, "Ф")
        };

        BookCollections bookCollections = new BookCollections();
        bookCollections.AddCollection(collection1);
        bookCollections.AddCollection(collection2);

        // Знайти кількість колекцій розміру 2
        int countOfSize2 = bookCollections.CountCollectionsWithSize(2);
        Console.WriteLine($"Кількість колекцій розміру 2: {countOfSize2}");

        // Знайти максимальну колекцію
        List<Book> maxCollection = bookCollections.GetMaxCollection();
        Console.WriteLine("Максимальна колекція:");
        foreach (Book book in maxCollection)
        {
            Console.WriteLine($"{book.Author}, Назва: {book.Title}, Рік випуску: {book.Year}, Група: {book.Group}");
        }

        // Знайти мінімальну колекцію
        List<Book> minCollection = bookCollections.GetMinCollection();
        Console.WriteLine("Мінімальна колекція:");
        foreach (Book book in minCollection)
        {
            Console.WriteLine($"{book.Author}, Назва: {book.Title}, Рік випуску: {book.Year}, Група: {book.Group}");
        }

        Console.ReadLine();
    }
}
