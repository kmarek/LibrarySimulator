using KamilMarek.Qa.LibrarySimulator.Core.Items;
using KamilMarek.Qa.LibrarySimulator.Core.Users;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests
{
    public class RentItemsTests : BaseTest
    {
        [Fact]
        public void Should_UserBeAbleToRentExistingBook()
        {
            Student student = UserHelper.GetRandomStudent();
            Book book = ItemHelper.GetRandomBook();

            Library.AddUserToLibrary(student);
            Library.AddItemToLibrary(book);

            Library.RentItemToUser(book, student)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Should_NotRentBook_When_BookIsNotInLibrary()
        {
            Student student = UserHelper.GetRandomStudent();
            Book book = ItemHelper.GetRandomBook();

            Library.AddUserToLibrary(student);

            Library.RentItemToUser(book, student)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_NotRentMagazine_When_MagazineIsNotInLibrary()
        {
            Student student = UserHelper.GetRandomStudent();
            Magazine magazine = ItemHelper.GetRandomMagazine();

            Library.AddUserToLibrary(student);

            Library.RentItemToUser(magazine, student)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_NotRentItem_When_UserIsNotRegistered()
        {
            Student student = UserHelper.GetRandomStudent();
            Book book = ItemHelper.GetRandomBook();

            Library.AddItemToLibrary(book);

            Library.RentItemToUser(book, student)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_NotRentItem_When_OtherItemWithTheSameDataIsRegistered()
        {
            Student student = UserHelper.GetRandomStudent();
            Book book = ItemHelper.GetRandomBook();

            Library.AddUserToLibrary(student);
            Library.AddItemToLibrary(book);

            Book notRegisteredBook = new(book.Author, book.Title);

            Library.RentItemToUser(notRegisteredBook, student)
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_NotRentMoreThan4Items_When_UserIsAStudent()
        {
            Student student = UserHelper.GetRandomStudent();
            List<Book> books = ItemHelper.GetRandomBooks(5);

            Library.AddUserToLibrary(student);
            Library.AddItemToLibrary(books.ToArray());

            Library.RentItemToUser(books[0], student).Should().BeTrue();
            Library.RentItemToUser(books[1], student).Should().BeTrue();
            Library.RentItemToUser(books[2], student).Should().BeTrue();
            Library.RentItemToUser(books[3], student).Should().BeTrue();
            Library.RentItemToUser(books[4], student).Should().BeFalse();
        }

        [Fact]
        public void Should_NotRentMoreThan10Items_When_UserIsALecturere()
        {
            Lecturer lecturer = UserHelper.GetRandomLecturer();
            List<Book> books = ItemHelper.GetRandomBooks(11);

            Library.AddUserToLibrary(lecturer);
            Library.AddItemToLibrary(books.ToArray());

            Library.RentItemToUser(books[0], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[1], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[2], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[3], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[4], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[5], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[6], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[7], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[8], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[9], lecturer).Should().BeTrue();
            Library.RentItemToUser(books[10], lecturer).Should().BeFalse();

            Library.GetRentedCount(lecturer).Should().Be(10);
        }

        [Fact]
        public void Should_NotBeAbleToRentAlreadyRentedItem()
        {
            Magazine magazine = ItemHelper.GetRandomMagazine();
            Student student = UserHelper.GetRandomStudent();

            Library.AddUserToLibrary(student);
            Library.AddItemToLibrary(magazine);

            Library.RentItemToUser(magazine, student);
            Library.RentItemToUser(magazine, student)
                .Should().BeFalse();
            Library.GetRentedCount(student).Should().Be(1);
        }
    }
}
