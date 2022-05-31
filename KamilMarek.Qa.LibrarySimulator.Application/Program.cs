using KamilMarek.Qa.LibrarySimulator.Core.Items;
using KamilMarek.Qa.LibrarySimulator.Core.Users;

namespace KamilMarek.Qa.LibrarySimulator.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Core.Library library = new();
            library.AddUserToLibrary(new Student("Kamil", "Marek"));
            library.AddUserToLibrary(new Lecturer("Kamil", "Marek"));
            library.PrintListOfUsers();

            library.AddItemToLibrary(new Book("J.R.R. Tolkien", "The Hobbit"));
            library.AddItemToLibrary(new Magazine("National Geographic", "01/2016"));
            library.PrintListOfBooks();
            library.PrintListOfMagazines();
        }
    }
}