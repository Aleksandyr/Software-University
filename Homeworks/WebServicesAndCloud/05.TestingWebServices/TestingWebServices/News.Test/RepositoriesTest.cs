using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Data;
using News.Data.Repositories;

namespace News.Test
{
    [TestClass]
    public class RepositoriesTest
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            //Start a new temporary transaction
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //Rollback the temporary transaction
            tran.Dispose();
        }

        [TestMethod]
        public void AddNewsWhenNewsIsAddedToDbShouldReturnNews()
        {
            //Arange -> prepare the objects
            var repo = new Repository<Models.News>(new NewsContext());
            var news = new Models.News()
            {
                Id = 1,
                Title = "title 1",
                Content = "content 1",
                PublishedData = DateTime.Now
            };

            //Act -> perform some logic
            repo.Add(news);
            repo.SaveChanges();

            //Assert -> validate the results
            var newsFromDb = repo.GetById(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.PublishedData, newsFromDb.PublishedData);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void AddNewsWhenNewsIsInvalidShouldThrowException()
        {
            //Arrange -> prepare the objects
            var repo = new Repository<Models.News>(new NewsContext());
            var invalidNews = new Models.News()
            {
                Content = null
            };

            //Act -> perform some logic
            repo.Add(invalidNews);
            repo.SaveChanges();

            //Assert -> expect an exception
        }

        [TestMethod]
        public void DeleteNewsWhenExistingItemShouldDelete()
        {
            //Arrange -> prepare the objects
            var repo = new Repository<Models.News>(new NewsContext());
            var news = new Models.News()
            {
                Id = 1,
                Title = "1",
                Content = "1",
                PublishedData = DateTime.Now
            };

            //Act -> perform some logic
            repo.Add(news);
            repo.SaveChanges();

            var newsFromDb = repo.GetById(news.Id);

            repo.Delete(newsFromDb);
            repo.SaveChanges();

            var newNewsFromDb = repo.GetById(news.Id);

            Assert.IsNull(newNewsFromDb);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNewsWhenNotExistShouldThrowException()
        {
            var repo = new Repository<Models.News>(new NewsContext());
            var news = repo.GetById(123);
            repo.Delete(news);
        }

        [TestMethod]
        public void ModifyNewsWhenExistingItemShouldModify()
        {
            var repo = new Repository<Models.News>(new NewsContext());
            var news = new Models.News()
            {
                Id = 1,
                Title = "1",
                Content = "1",
                PublishedData = DateTime.Now
            };

            //Act -> perform some logic
            repo.Add(news);
            repo.SaveChanges();

            news.Title = "2";
            news.Content = "2";

            repo.Update(news);
            repo.SaveChanges();

            var newsFromDb = repo.GetById(news.Id);
            
            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual("2", newsFromDb.Title);
            Assert.AreEqual("2", newsFromDb.Content);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        public void ListAllNewsShouldReturnAllNews()
        {
            var repo = new Repository<Models.News>(new NewsContext());
            var fakeNews = new List<Models.News>()
            {
                new Models.News()
                {
                    Id = 1,
                    Title = "1",
                    Content = "1",
                    PublishedData = new DateTime(2015, 01, 01)
                },
                new Models.News()
                {
                    Id = 2,
                    Title = "2",
                    Content = "2",
                    PublishedData = new DateTime(2015, 01, 02)
                },
                new Models.News()
                {
                    Id = 3,
                    Title = "3",
                    Content = "3",
                    PublishedData = new DateTime(2015, 01, 03)
                }
            };

            foreach (var fakeNew in fakeNews)
            {
                repo.Add(fakeNew);
                repo.SaveChanges();
            }

            var fakeNewsTitles = fakeNews.Select(n => n.Title).ToList();
            var newsDbTitles = repo.All().Select(n => n.Title).ToList();

            CollectionAssert.AreEqual(fakeNewsTitles, newsDbTitles);
        }
    }
}
