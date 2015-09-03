using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Services.Controllers;
using OnlineShop.Services.Models.ViewModels;

namespace OnlineShop.Tests
{
    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
        }

        [TestMethod]
        public void TestGetAdsShouldReturnAllAdsSortedByType()
        {
            var mockedContext = new Mock<IOnlineShopData>();
            mockedContext.Setup(c => c.Ads).Returns(this.mocks.AdRepositoryMock.Object);
            var adsController = new AdsController(mockedContext.Object);

            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
            var response = adsController.GetAds().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseAds = response.Content
                .ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result
                .Select(a => a.Id)
                .ToList();
            var fakeAds = this.mocks.AdRepositoryMock.Object.All()
                .Select(AdViewModel.Create)
                .OrderBy(a => a.Type)
                .ThenBy(a => a.PostedOn)
                .Select(a => a.Id)
                .ToList();
            CollectionAssert.AreEqual(fakeAds, responseAds);
        }

        [TestMethod]
        public void CreateAd_Should_Successfully_Add_To_Repository()
        {
            var ads = new List<Ad>();

            var fakeUser = this.mocks.UserRepositoryMock.Object.All().FirstOrDefault();
            if (fakeUser != null)
            {
                Assert.Fail("Cannot perform test - no users available.");
            }

            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                });        
        } 
        
    }
}
