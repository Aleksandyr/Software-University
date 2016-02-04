namespace BULS.Tests
{
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
        
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        private IRepository<User> users;

        [TestInitialize]
        public void InitializeUsers()
        {
            this.users = new Repository<User>();    
        }

        [TestMethod]
        public void GetValidIdShouldReturnElement()
        {
            const int validId = 1;

            var userList = new List<User>()
            {
                new User("Pesho", "123456", Role.Lecturer),
                new User("Gosho", "34ersd", Role.Student),
            };

            foreach (User user in userList)
            {
                this.users.Add(user);
            }

            var actualUser = this.users.Get(validId);

            Assert.AreEqual(userList[0], actualUser);
        }

        [TestMethod]
        public void GetInvalidIdShouldReturnDefault()
        {
            const int validId = 1;

            var actualUser = this.users.Get(validId);

            Assert.AreEqual(default(User), actualUser);
        }

        [TestMethod]
        public void GetIdMoreThanCountOfUsersShouldReturnDefault()
        {
            var userList = new List<User>()
            {
                new User("Pesho", "123456", Role.Lecturer),
                new User("Gosho", "34ersd", Role.Student),
            };

            int id = userList.Count + 1;

            foreach (User user in userList)
            {
                this.users.Add(user);
            }

            var actualUser = this.users.Get(id);

            Assert.AreEqual(default(User), actualUser);
        }
    }
}
