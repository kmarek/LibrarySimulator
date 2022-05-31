using KamilMarek.Qa.LibrarySimulator.Library.Items;
using KamilMarek.Qa.LibrarySimulator.Library.Users;

namespace KamilMarek.Qa.LibrarySimulator.Library
{
    public class Library
    {
        private const int MaxItemsCountStudent = 4;
        private const int MaxItemsCountLecturer = 10;
        private List<Item> _items;
        private List<User> _users;
        private int _availableCardNumber;

        public Library()
        {
            _items = new List<Item>();
            _users = new List<User>();
            _availableCardNumber = 1;
        }

        #region Required Methods

        public void AddUserToLibrary(params User[] users)
        {
            users.ToList().ForEach(user => AddUser(user));
        }

        public void AddItemToLibrary(params Item[] items)
        {
            items.ToList().ForEach(item => _items.Add(item));
        }

        public bool RentItemToUser(Item item, User user)
        {
            return false;
        }

        public void PrintListOfMagazines()
        {

        }

        public void PrintListOfBooks()
        {

        }

        public void PrintListOfUsers()
        {

        }

        public void ImportItemsFromFile(string csvFile)
        {

        }

        public void ExportUsersWithItemsToFile(string csvFile)
        {

        }

        #endregion

        #region Additional Public Methods

        public List<Item> GetItems() => _items;
        public List<User> GetUsers() => _users;

        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            if (user is Student)
            {
                Student student = new(user.FirstName, user.LastName);
                student.LibraryCard = new LibraryCard(_availableCardNumber++, MaxItemsCountStudent);
                _users.Add(student);
            }
            else
            {
                Lecturer lecturer = new(user.FirstName, user.LastName);
                lecturer.LibraryCard = new LibraryCard(_availableCardNumber++, MaxItemsCountLecturer);
                _users.Add(lecturer);
            }
        }

        #endregion
    }
}