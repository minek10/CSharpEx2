using DemoApp.Data.Context;
using DemoApp.Data.Enum;
using DemoApp.Data.Model;
using DemoApp.Repository;
using DemoApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAll()
        {
            //Model AAA

            //Arrange
            var options = new DbContextOptionsBuilder<DemoAppDBContext>().UseInMemoryDatabase(databaseName: "DemoAppDb").Options;

            //Insert seed data into the database using one instance of the context
            using (var context = new DemoAppDBContext(options))
            {
                context.Users.Add(new User() { LastName = "Michel", FirstName = "Drucker" });
                context.Users.Add(new User() { LastName = "Michel", FirstName = "Fugain" });
                context.Users.Add(new User() { LastName = "Patrick", FirstName = "Bruel" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DemoAppDBContext(options))
            {
                //Act
                IUserRepository userRepository = new UserRepository(context);
                var users = userRepository.Get();

                //Assert
                Assert.NotNull(users);
            }
        }

        [Fact]
        public void TestGetAllWithFilter()
        {
            //Model AAA

            //Arrange
            var options = new DbContextOptionsBuilder<DemoAppDBContext>().UseInMemoryDatabase(databaseName: "DemoAppDb").Options;

            //Insert seed data into the database using one instance of the context
            using (var context = new DemoAppDBContext(options))
            {
                context.Users.Add(new User() { LastName = "Michel", FirstName = "Drucker" });
                context.Users.Add(new User() { LastName = "Michel", FirstName = "Fugain" });
                context.Users.Add(new User() { LastName = "Patrick", FirstName = "Bruel" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DemoAppDBContext(options))
            {
                //Act
                IUserRepository userRepository = new UserRepository(context);
                var users = userRepository.GetUsersFilter("el", KindOfFilter.Prenom);

                //Assert
                Assert.NotNull(users);
            }
        }
    }
}
