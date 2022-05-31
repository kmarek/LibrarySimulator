using KamilMarek.Qa.LibrarySimulator.Core.LibraryItems;

namespace KamilMarek.Qa.LibrarySimulator.Core.Users
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int LibraryCardId { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
