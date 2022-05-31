namespace KamilMarek.Qa.LibrarySimulator.Core.Items
{
    public class Magazine : Item
    {
        public string Number { get; set; }
        public Magazine(string title, string number) : base(title)
        {
            Number = number;
        }
    }
}
