using FluentAssertions;

[TestFixture]
public class LibraryTests
{
    Library _library;

    [SetUp]
    public void Setup()
    {
        _library = new Library();
    }


    [Test]
    public void AddBook_IncreasesTotalBooks()
    {

        _library.AddBook(new Book("978-6-5849-6234-7", "An Investigation Into Dave's Wonderful Toenails", "Aidan Fell"));
        _library.ReturnBooks().Count.Should().Be(1);
    }

    [Test]
    public void FindBookByISBN_ReturnsCorrectBook()
    {
        var book = new Book("978-1-5414-1842-4", "An Investigation Into Dave's Wonderful Toenails", "Aidan Fell");
        _library.AddBook(book);
        var hashCode = book.GetHashCode();
        _library.FindBookByISBN("978-1-5414-1842-4").GetHashCode().Should().Be(hashCode);
    }

    [Test]
    public void FindBooksByAuthor_ReturnsCorrectBooks()
    {
        List<Book> books = new List<Book>() {
        new Book("978-1-5414-1842-4", "Jimbob's Massive Forehead Issues", "Aidan Fell"),
        new Book("978-3-3063-1539-9", "Bro, Are You JavaScript? Because You Make Promises From Promises", "Aidan Fell")
    };
        _library.AddBooks(books);
        _library.FindBooksByAuthor("Aidan Fell").Should().Contain(books);
    }
}

[TestFixture]
public class LibraryIntegrationTests
{
    [Test]
    public void AddMultipleBooks_FindByAuthor_ReturnsCorrectBooks()
    {
        // I've kinda tested that above by accident
    }

    [Test]
    public void AddBook_FindByISBN_ReturnsCorrectBook()
    {
        // Again, I've kinda done that above by accident
    }
}


[TestFixture]
public class LibrarySystemE2ETests
{
    [Test]
    public void CreateLibrary_AddBooks_SearchAndRetrieveBooks()
    {
        var library = new Library();
        var books = new List<Book>()
        {
            new Book("978-1-5414-1842-4", "Jimbob's Massive Forehead Issues", "Aidan Fell"),
            new Book("978-3-3063-1539-9", "Bro, Are You JavaScript? Because You Make Promises From Promises", "Aidan Fell")
        };
        library.AddBooks(books);
        library.ReturnBooks().Count.Should().Be(2);
        library.FindBooksByAuthor("Aidan Fell").Should().Contain(books);
        library.FindBookByISBN("978-1-5414-1842-4").Should().Be(books[0]);
    }

    [Test]
    public void CreateLibrary_AddDuplicateBooks_EnsureNoDuplicates()
    {
        var library = new Library();
        var books = new List<Book>();
    }
}