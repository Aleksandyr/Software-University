using System;
using BangaloreUniversityLearningSystem.Controllers;
using BangaloreUniversityLearningSystem.Data;
using BangaloreUniversityLearningSystem.Enums;
using BangaloreUniversityLearningSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULS.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private UsersController controller;

        [TestInitialize]
        public void InitializeUsersController()
        {
            var data = new BangaloreUniversityData();
            this.controller = new UsersController(data, null);       
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryLogoutWithoutHaveLoggedUserShouldThrow()
        {
            this.controller.Logout();
        }

        [TestMethod]
        public void LogoutShouldSetUserToBeNull()
        {
            var user = new User("Pesho", "435321", Role.Lecturer);
            this.controller.User = user;

            Assert.AreEqual(this.controller.User, user);

            this.controller.Logout();

            Assert.AreEqual(this.controller.User, null);
        }

        [TestMethod]
        public void LogoutShouldReturnViewDifferentFromNull()
        {
            var user = new User("Pesho", "435321", Role.Lecturer);
            this.controller.User = user;

            Assert.AreEqual(this.controller.User, user);

            var actualResult = this.controller.Logout().Model;
            //var expectedResult = string.Format("User {0} logged out successfully.", user.Username);

            Assert.AreNotEqual(null, actualResult);
        }
    }
}
