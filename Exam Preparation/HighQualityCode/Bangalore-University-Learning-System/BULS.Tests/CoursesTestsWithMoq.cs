using System.Linq;
using BangaloreUniversityLearningSystem.Controllers;
using BangaloreUniversityLearningSystem.Enums;
using BangaloreUniversityLearningSystem.Interfaces;
using BangaloreUniversityLearningSystem.Models;
using Moq;

namespace BULS.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoursesTestsWithMoq
    {
        private IBangaloreUniversityData mockedData;
        private Course course;

        [TestInitialize]
        public void InitializeMocks()
        {
            var dataMock = new Mock<IBangaloreUniversityData>();
            var courseRepoMock = new Mock<IRepository<Course>>();
            this.course = new Course("C# basics");

            courseRepoMock.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(this.course);

            dataMock.Setup(d => d.Courses)
                .Returns(courseRepoMock.Object);

            this.mockedData = dataMock.Object;
        }

        [TestMethod]
        public void AddLectureExistingCourseShouldAddToCourse()
        {
            var user = new User("Aleksandar", "rwesfdf", Role.Lecturer);
            var controller = new CoursesController(this.mockedData, user);

            const string lectureName = "Using computers";

            var view = controller.AddLecture(5, lectureName);

            Assert.AreEqual(this.course.Lectures.First().Name, lectureName);
            Assert.IsNotNull(view);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLectureInvalidCourseIdShouldThrow()
        {
            
        }
    }
}
