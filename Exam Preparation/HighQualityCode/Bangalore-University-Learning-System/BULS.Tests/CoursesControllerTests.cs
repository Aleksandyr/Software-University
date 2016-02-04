namespace BULS.Tests
{
    using System.Collections.Generic;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoursesControllerTests
    {
        private CoursesController controller;

        [TestInitialize]
        public void InitializeCoursesController()
        {
            var data = new BangaloreUniversityData();
            var user = new User("pesho", "32432we", Role.Lecturer);
            this.controller = new CoursesController(data, user);
        }

        [TestMethod]
        public void AllMethodShouldReturnAllCoursesSortedByNameAndStudnetsCount()
        {
            var courses = new List<Course>()
            {
                new Course("Advanced C#"),
                new Course("Java Basics"),
                new Course("PHP Basics"),
            };

            this.controller.Create(courses[1].Name);
            this.controller.Create(courses[2].Name);
            this.controller.Create(courses[0].Name);

            var actualResult = this.controller.All().Display();
            var expectedResult = "All courses:\r\nAdvanced C# (0 students)\r\nJava Basics (0 students)\r\nPHP Basics (0 students)";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetAllCoursesWithoutHaveAnyShouldReturnNoCourses()
        {
            var actualResult = this.controller.All().Display();
            var expectedResult = "No courses.";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
