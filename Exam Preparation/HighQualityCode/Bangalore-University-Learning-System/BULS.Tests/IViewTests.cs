using System;
using BangaloreUniversityLearningSystem.Enums;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Models;
using BangaloreUniversityLearningSystem.Utilities;
using BangaloreUniversityLearningSystem.Views.Users;

namespace BULS.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IViewTests
    {
        //private IView view;
        [TestInitialize]
        public void InitializeIviewModel()
        {
            //this.view = new Logout();
        }

        [TestMethod]
        public void ValidUserShouldReturnCorrectString()
        {
            var user = new User("Pesho", "123455", Role.Student);
            var view = new Logout(user);

            string actualString = string.Format("User {0} logged out successfully.", user.Username);
            string expectedString = view.Display();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
