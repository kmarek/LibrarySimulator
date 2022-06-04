using KamilMarek.Qa.LibrarySimulator.Core.Items;
using KamilMarek.Qa.LibrarySimulator.Core.LibraryItems;
using KamilMarek.Qa.LibrarySimulator.Core.Users;

namespace KamilMarek.Qa.LibrarySimulator.Core
{
    public class Library
    {
        private const int MaxItemsCountStudent = 4;
        private const int MaxItemsCountLecturer = 10;
        private List<ItemCard> _itemCards;
        private List<UserCard> _userCards;
        private int _availableUserCardNumber;
        private int _availableItemCardNumber;

        public Library()
        {
            _itemCards = new List<ItemCard>();
            _userCards = new List<UserCard>();
            _availableUserCardNumber = 1;
            _availableItemCardNumber = 1;
        }

        #region Required Methods

        public void AddUserToLibrary(params User[] users)
        {
            users.ToList().ForEach(user => AddUser(user));
        }

        public void AddItemToLibrary(params Item[] items)
        {
            items.ToList().ForEach(item => AddItem(item));
        }

        public bool RentItemToUser(Item item, User user)
        {
            return false;
        }

        public void PrintListOfMagazines()
        {
            Console.WriteLine($"List of {_itemCards.Count(i => i.Type == 'M')} Magazines");

            _itemCards.Where(i => i.Type == 'M').ToList().ForEach(item =>
            {
                Console.WriteLine($"{item.Title};{item.AuthorOrNumber};");
            });
        }

        public void PrintListOfBooks()
        {
            Console.WriteLine($"List of {_itemCards.Count(i => i.Type == 'B')} Magazines");

            _itemCards.Where(i => i.Type == 'B').ToList().ForEach(item =>
            {
                Console.WriteLine($"{item.Title};{item.AuthorOrNumber};");
            });
        }

        public void PrintListOfUsers()
        {
            Console.WriteLine($"List of {_userCards.Count} Users.");

            _userCards.ForEach(user =>
            {
                Console.WriteLine($"{user.FirstName};{user.LastName};{user.Id};{user.Type}");
            });
        }

        public void ImportItemsFromFile(string csvFile)
        {

        }

        public void ExportUsersWithItemsToFile(string csvFile)
        {

        }

        #endregion

        #region Additional Public Methods

        public List<ItemCard> GetItems() => _itemCards;
        public int GetUniqueItemCount() => GetUniqueBookCount() + GetUniqueMagazineCount();
        public List<UserCard> GetUsers() => _userCards;

        #endregion

        #region Private Methods

        private void AddUser(User user)
        {
            int maxCount = user is Student ? MaxItemsCountStudent : MaxItemsCountLecturer;
            char type = user is Student ? 'S' : 'L';

            UserCard userCard = new(_availableUserCardNumber++, user.FirstName, user.LastName, maxCount);
            userCard.Type = type;

            _userCards.Add(userCard);
        }

        private void AddItem(Item item)
        {
            string authorOrNumber;
            char type = item is Book ? 'B' : 'M';

            if (item is Book)
            {
                Book book = (Book)item;
                authorOrNumber = book.Author;
                type = 'B';
            }
            else
            {
                Magazine magazine = (Magazine)item;
                authorOrNumber = magazine.Number;
                type = 'M';
            }

            ItemCard itemCard = new(_availableItemCardNumber++, item.Title, type, authorOrNumber);
            _itemCards.Add(itemCard);
        }

        private int GetUniqueBookCount() => _itemCards
            .Where(i => i.Type == 'B')
            .GroupBy(item => item.Title + item.AuthorOrNumber)
            .Count();

        private int GetUniqueMagazineCount() => _itemCards
            .Where(i => i.Type == 'M')
            .GroupBy(item => item.Title + item.AuthorOrNumber)
            .Count();

        #endregion
    }
}