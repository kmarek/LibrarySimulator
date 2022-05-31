using Bogus;
using KamilMarek.Qa.LibrarySimulator.Core;

namespace KamilMarek.Qa.LibrarySimulator.Library.UnitTests
{
    public class BaseTest
    {
        protected readonly KamilMarek.Qa.LibrarySimulator.Core.Library Library;
        protected Faker Faker;

        public BaseTest()
        {
            Library = new Core.Library();
            Faker = new Faker();
        }
    }
}
