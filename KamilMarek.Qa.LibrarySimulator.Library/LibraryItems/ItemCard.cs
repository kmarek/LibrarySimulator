namespace KamilMarek.Qa.LibrarySimulator.Core.LibraryItems
{
    public class ItemCard
    {
        public int Id { get; private set; }
        public string AuthorOrNumber { get; set; }
        public string Title { get; set; }
        public char Type { get; set; }

        public ItemCard(int id, string title, char type, string authorOrNumber)
        {
            Id = id;
            Title = title;
            AuthorOrNumber = authorOrNumber;
            Type = type;
        }
    }
}
