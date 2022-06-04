using KamilMarek.Qa.LibrarySimulator.Core.Users;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests
{
    public class AddingUsersTests : BaseTest
    {
        [Fact]
        public void Should_CreateLibrary_WithoutUsers()
        {
            Library.GetUsers().Should().BeEmpty();
        }

        [Fact]
        public void Should_AddStudentToLibrary_When_StudentIsNotInLibrary()
        {
            Student student = UserHelper.GetRandomStudent();

            Library.AddUserToLibrary(student);
            Library.GetUsers().Count.Should().Be(1);
        }

        [Fact]
        public void Should_AddStudentToLibrary_When_StudentWithTheSameNameAlreadyExists()
        {
            Student student = UserHelper.GetRandomStudent();

            Library.AddUserToLibrary(student);
            Library.AddUserToLibrary(student);
            Library.GetUsers().Count.Should().Be(2);
        }

        [Fact]
        public void Should_AddLecturerToLibrary_When_LecturerIsNotInLibrary()
        {
            Lecturer lecturer = UserHelper.GetRandomLecturer();

            Library.AddUserToLibrary(lecturer);
            Library.GetUsers().Count.Should().Be(1);
            Library.GetUsers().First().Id.Should().Be(1);
        }

        [Fact]
        public void Should_AddLecturerToLibrary_When_LecturerWithTheSameNameAlreadyExists()
        {
            Lecturer lecturer = UserHelper.GetRandomLecturer();

            Library.AddUserToLibrary(lecturer);
            Library.AddUserToLibrary(lecturer);
            Library.GetUsers().Count.Should().Be(2);
        }

        [Fact]
        public void Should_SetCardId_When_LecturerIsAddedToLibrary()
        {
            Lecturer lecturer = UserHelper.GetRandomLecturer();

            Library.AddUserToLibrary(lecturer);
            Library.GetUsers().First().Id.Should().Be(1);
        }

        [Fact]
        public void Should_StudentBeAddedAsANewUser_When_UserWithTheSameNameAlreadyExists()
        {
            Lecturer lecturer = UserHelper.GetRandomLecturer();

            Library.AddUserToLibrary(lecturer);
            Library.AddUserToLibrary(lecturer);

            var libraryUsers = Library.GetUsers();
            libraryUsers.Count.Should().Be(2);
            libraryUsers[0].Id.Should().Be(1);
            libraryUsers[1].Id.Should().Be(2);
        }
    }
}
