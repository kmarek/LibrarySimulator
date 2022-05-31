using KamilMarek.Qa.LibrarySimulator.Core.Items;

namespace KamilMarek.Qa.LibrarySimulator.Core.LibraryItems
{
    public class UserCard
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ItemCard> RentedItems { get; set; }
        public int MaxItemsCount { get; private set; }
        public char Type { get; set; }

        public UserCard(int id, string firstName, string lastName, int maxItemsCount)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            MaxItemsCount = maxItemsCount;
            RentedItems = new List<ItemCard>();
        }
    }
}
