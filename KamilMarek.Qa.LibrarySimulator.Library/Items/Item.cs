namespace KamilMarek.Qa.LibrarySimulator.Core.Items
{
    public class Item
    {
        public string Title { get; private set; }
        public int CardId { get; set; }

        public Item(string title)
        {
            Title = title;
        }
    }
}
