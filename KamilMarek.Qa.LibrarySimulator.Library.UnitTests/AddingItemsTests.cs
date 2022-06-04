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
            Book book1 = ItemHelper.GetRandomBook();
            Book book2 = ItemHelper.GetRandomBook();

            Library.AddItemToLibrary(book1, book2);
            Library.GetItems().Count.Should().Be(2);
        }

        [Fact]
        public void Should_AddManyMagazinesToLibraryAtOnce()
        {
            Magazine magazine1 = ItemHelper.GetRandomMagazine();
            Magazine magazine2 = ItemHelper.GetRandomMagazine();
            Magazine magazine3 = ItemHelper.GetRandomMagazine();

            Library.AddItemToLibrary(magazine1, magazine2, magazine3);
            Library.GetItems().Count.Should().Be(3);
        }

        [Fact]
        public void Should_AddManyBooksOrMagazinesToLibraryAtOnce()
        {
            Magazine magazine1 = ItemHelper.GetRandomMagazine();
            Magazine magazine2 = ItemHelper.GetRandomMagazine();
            Book book1 = ItemHelper.GetRandomBook();
            Book book2 = ItemHelper.GetRandomBook();

            Library.AddItemToLibrary(magazine1, book1, magazine2, book2);
            Library.GetItems().Count.Should().Be(4);
        }

        [Fact]
        public void Should_IncreaseCount_When_TheSameBookIsAlreadyInLibrary()
        {
            Book book = ItemHelper.GetRandomBook();

            Library.AddItemToLibrary(book, book);
            Library.GetUniqueItemCount().Should().Be(1);
        }

        [Fact]
        public void Should_NotIncreaseCount_When_TheSameMagazineIsAlreadyInLibrary()
        {
            Book book = ItemHelper.GetRandomBook();
            Magazine magazine = new(book.Title, book.Author);

            Library.AddItemToLibrary(magazine);
            Library.AddItemToLibrary(book);
            Library.GetUniqueItemCount().Should().Be(2);
        }
    }
}