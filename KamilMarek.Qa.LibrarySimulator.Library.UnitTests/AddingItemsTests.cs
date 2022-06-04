using KamilMarek.Qa.LibrarySimulator.Core.Items;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests
{
    public class AddingItemsTests : BaseTest
    {
        [Fact]
        public void Should_CreateLibrary_WithoutItems()
        {
            Library.GetItems().Should().BeEmpty();
        }

        [Fact]
        public void Should_AddBookToLibrary_When_ItemIsNotInLibrary()
        {
            Book book = ItemHelper.GetRandomBook();

            Library.AddItemToLibrary(book);
            Library.GetItems().Count.Should().Be(1);
        }

        [Fact]
        public void Should_AddManyBooksToLibraryAtOnce()
        {
            Book book1 = new("J.R.R. Tolkien", "The Hobbit");
            Book book2 = new("J.R.R. Tolkien", "The Silmarillion");

            Library.AddItemToLibrary(book1, book2);
            Library.GetItems().Count.Should().Be(2);
        }

        [Fact]
        public void Should_AddManyMagazinesToLibraryAtOnce()
        {
            Magazine magazine1 = new("National Geographic", "01/2016");
            Magazine magazine2 = new("National Geographic", "02/2016");
            Magazine magazine3 = new("National Geographic", "03/2016");

            Library.AddItemToLibrary(magazine1, magazine2, magazine3);
            Library.GetItems().Count.Should().Be(3);
        }

        [Fact]
        public void Should_AddManyBooksOrMagazinesToLibraryAtOnce()
        {
            Magazine magazine1 = new("National Geographic", "01/2016");
            Magazine magazine2 = new("National Geographic", "02/2016");
            Book book1 = new("J.R.R. Tolkien", "The Hobbit");
            Book book2 = new("J.R.R. Tolkien", "The Silmarillion");

            Library.AddItemToLibrary(magazine1, book1, magazine2, book2);
            Library.GetItems().Count.Should().Be(4);
        }
    }
}