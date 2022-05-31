namespace KamilMarek.Qa.LibrarySimulator.Library.Users
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public LibraryCard? LibraryCard { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int GetCardId() => LibraryCard?.CardId ?? 0;
    }
}
