using Bogus;
using KamilMarek.Qa.LibrarySimulator.Core.Items;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests.TestData
{
    public class ItemHelper
    {
        private Faker _faker;

        public ItemHelper()
        {
            _faker = new Faker();
        }

        public Book GetRandomBook()
        {
            return new(_faker.Person.FullName, $"B_{_faker.Commerce.ProductDescription()}");
        }

        public List<Book> GetRandomBooks(int count)
        {
            var list = new List<Book>();

            for (int i = 0; i < count; i++)
            {
                list.Add(GetRandomBook());
            }

            return list;
        }

        public Magazine GetRandomMagazine()
        {
            return new(_faker.Person.FullName, $"M_{_faker.Commerce.ProductDescription()}");
        }
    }
}
