using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Data.DataLayer;
using News.Data.Repositories;
using News.WebService.Controllers;
using News.WebService.Models;
using News.WebService.Models.BindingModels;

namespace News.Test
{
    [TestClass]
    public class NewsControllerTests
    {
        [TestMethod]
        public void TestGetAllPostWhenHasNewsShouldReturnNewsSortedDescendingByDate()
        {
            //Setup fake news
            var fakeNews = new List<Models.News>()
            {
                new Models.News()
                {
                    Id = 1,
                    Title = "1",
                    Content = "1",
                    PublishedData = new DateTime(2000, 01, 01)
                },
                new Models.News()
                {
                    Id = 2,
                    Title = "2",
                    Content = "2",
                    PublishedData = new DateTime(2000, 01, 02)
                },
                new Models.News()
                {
                    Id = 3,
                    Title = "3",
                    Content = "3",
                    PublishedData = new DateTime(2000, 01, 03)
                }
            };

            //Setup repositories
            var mockedRepository = new Mock<IRepository<Models.News>>();
            mockedRepository.Setup(r => r.All()).Returns(fakeNews.AsQueryable());

            //Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);

            //Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.GetNews().ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var news = response.Content
                .ReadAsAsync<IEnumerable<NewsViewModel>>()
                .Result
                .Select(n => n.Title)
                .ToList();

            var orderedFakeNews = fakeNews
                .OrderByDescending(n => n.PublishedData)
                .Select(n => n.Title)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeNews, news);
        }

        [TestMethod]
        public void TestPostNewNewsWithValidDataShouldAddNewNews()
        {
            //Setup fake news
            var fakeNews = new List<Models.News>();
            var isNewsSaved = false;

            //Setup repositories
            var mockedRepository = new Mock<IRepository<Models.News>>();
            mockedRepository.Setup(r => r.Add(It.IsAny<Models.News>()))
                .Callback((Models.News n) =>
                {
                    fakeNews.Add(n);
                });

            //Setup data layer
            var mockedContext = new Mock<INewsData>();
            mockedContext.Setup(c => c.News).Returns(mockedRepository.Object);
            mockedContext.Setup(r => r.SaveChanges())
                .Callback(() =>
                {
                    isNewsSaved = true;
                });

            // Setup controller
            var controller = new NewsController(mockedContext.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.PostNewNews(new NewsBindingModel()
            {
                Content = "test",
                Title = "test",
                PublishDate = DateTime.Now,
            }).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var news = response.Content
                .ReadAsAsync<NewsViewModel>()
                .Result;

            var orderedFakeNews = fakeNews
                .Select(n => n.Title)
                .ToList();

            Assert.AreEqual(orderedFakeNews[0], news.Title);
            Assert.IsTrue(isNewsSaved);
        }



    }
}