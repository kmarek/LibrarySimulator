namespace KamilMarek.Qa.LibrarySimulator.Core.Items
{
    public class Book : Item
    {
        public string Author { get; private set; }

        public Book(string author, string title) : base(title)
        {
            Author = author;
        }
    }
}
