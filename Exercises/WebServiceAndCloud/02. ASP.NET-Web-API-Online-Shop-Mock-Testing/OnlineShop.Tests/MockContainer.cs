using System;
using Moq;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Tests
{
    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeCategories();
            this.SetupFakeUsers();
            this.SetupFakeAds();
            this.SetupFakeAdTypes();
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType() {Id = 1, Name = "Normal", Index = 100 },
                new AdType() {Id = 2, Name = "Premium", Index = 200 },
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());

            this.AdTypeRepositoryMock.Setup(r => r.Fing(It.IsAny<int>()))
                .Returns((int id) => (fakeAdTypes.Find(adtype => adtype.Id == id)));
        }

        private void SetupFakeAds()
        {

            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 1,
                    Name = "Audi A6",
                    Type = new AdType() {Name = "Normal", Index = 101},
                    PostedOn = DateTime.Now.AddDays(-6),
                    Owner = new ApplicationUser() {UserName = "gosho", Id = "123"},
                    Price = 400
                },
                new Ad()
                {
                    Id = 2,
                    Name = "Audi A8",
                    Type = new AdType() {Name = "Premium", Index = 102},
                    PostedOn = DateTime.Now.AddDays(-3),
                    Owner = new ApplicationUser() {UserName = "Pesho", Id = "121"},
                    Price = 700
                },
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Fing(It.IsAny<int>()))
                .Returns((int id) => (fakeAds.Find(ad => ad.Id == id)));
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "Kiro",
                    Id = "1"
                },
                new ApplicationUser()
                {
                    UserName = "Misho",
                    Id = "2"
                },
                new ApplicationUser()
                {
                    UserName = "Pencho",
                    Id = "3"
                }
            };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Fing(It.IsAny<string>()))
                .Returns((string id) => (fakeUsers.Find(user => user.Id == id)));
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Business"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Garden"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Toys"
                }
            };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(r => r.All())
                .Returns(fakeCategories.AsQueryable());

            this.CategoryRepositoryMock.Setup(r => r.Fing(It.IsAny<int>()))
                .Returns((int id) => (fakeCategories.Find(category => category.Id == id)));
        }
    }
}
