using Bogus;
using KamilMarek.Qa.LibrarySimulator.Core.Users;

namespace KamilMarek.Qa.LibrarySimulator.Core.UnitTests.TestData
{
    public class UserHelper
    {
        private Faker _faker;

        public UserHelper()
        {
            _faker = new Faker();
        }

        internal Student GetRandomStudent()
        {
            return new Student(_faker.Person.FirstName, $"S_{_faker.Person.LastName}");
        }

        internal Lecturer GetRandomLecturer()
        {
            return new Lecturer(_faker.Person.FirstName, $"L_{_faker.Person.LastName}");
        }
    }
}
