using KamilMarek.Qa.LibrarySimulator.Core.Items;

namespace KamilMarek.Qa.LibrarySimulator.Core.LibraryItems
{
    public class LibraryCard
    {
        public int CardId { get; init; }
        public List<Item> RentedItems { get; set; }
        public int MaxItemsCount { get; private set; }

        public LibraryCard(int cardId, int maxItemsCount)
        {
            CardId = cardId;
            MaxItemsCount = maxItemsCount;
            RentedItems = new List<Item>();
        }
    }
}
