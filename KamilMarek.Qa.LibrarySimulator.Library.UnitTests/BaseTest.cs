using Bogus;
using KamilMarek.Qa.LibrarySimulator.Core.UnitTests.TestData;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests
{
    public class BaseTest
    {
        protected readonly Library Library;
        protected Faker Faker;
        protected UserHelper UserHelper;
        protected ItemHelper ItemHelper;

        public BaseTest()
        {
            Library = new Library();
            Faker = new Faker();
            UserHelper = new UserHelper();
            ItemHelper = new ItemHelper();
        }
    }
}
