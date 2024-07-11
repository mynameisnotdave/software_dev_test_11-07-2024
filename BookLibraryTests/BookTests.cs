using FluentAssertions;
using NUnit.Framework;

[TestFixture]
public class BookTests
{
    [Test]
    public void BookConstructor_SetsPropertiesCorrectly()
    {
        var book = new Book("0-7933-0861-5", "DespairPoint: The Place of No Return", "Aidan Fell");
        book.ISBN.Should().Be("0-7933-0861-5");
        book.Title.Should().Be("DespairPoint: The Place of No Return");
        book.Author.Should().Be("Aidan Fell");
    }
}