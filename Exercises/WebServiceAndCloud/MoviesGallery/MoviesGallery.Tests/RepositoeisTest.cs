using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesGallery.Data;
using MoviesGallery.Data.Repositories;
using MoviesGallery.Models;

namespace MoviesGallery.Tests
{
    [TestClass]
    public class RepositoeisTest
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void AddMovieWhenMovieIsAddedToDbShouldReturnMovie()
        {
            //Arange -> prepare the objects
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var movie = new Movie()
            {
                Id = 1,
                Length = 1,
                Ration = 3
            };

            //Act -> perform some logic
            repo.Add(movie);
            repo.SaveChanges();

            //Assert -> validate the results
            var movieFromDb = repo.GetById(movie.Id);

            Assert.IsNotNull(movieFromDb);
            Assert.AreEqual(movie.Length, movieFromDb.Length);
            Assert.AreEqual(movie.Ration, movieFromDb.Ration);
            Assert.IsTrue(movieFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void AddMovieWhenMovieIsInvalidShouldThrowException()
        {
            //Arrange -> prepare the objects
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var invalidMovie = new Movie()
            {
                Id = 1,
                Length = 20,
                Ration = 20
            };

            //Act -> perform some logic
            repo.Add(invalidMovie);
            repo.SaveChanges();

            //Asssert -> expect and exception
        }

        [TestMethod]
        public void DeleteMovieWhenExistingItemShouldDelete()
        {
            //Arrange -> prepare the objects
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var movie = new Movie()
            {
                Id = 1,
                Length = 10,
                Ration = 10
            };

            //Act -> perform some logic
            repo.Add(movie);
            repo.SaveChanges();

            var movieFromDb = repo.GetById(movie.Id);

            repo.Delete(movieFromDb);
            repo.SaveChanges();

            var newMovieFromDb = repo.GetById(movie.Id);
            
            //Asssert -> expect and exception
            Assert.IsNull(newMovieFromDb);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteMovieWhenNotExistShouldThrowException()
        {
            //Arrange -> prepare the objects
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var movie = repo.GetById(234);
            repo.Delete(movie);

        }

        [TestMethod]
        public void ModifyMovieWhenExistingItemShouldModify()
        {
            //Arrange -> prepare the objects
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var movie = new Movie()
            {
                Id = 1,
                Length = 10,
                Ration = 10
            };

            //Act -> perform some logic
            repo.Add(movie);
            repo.SaveChanges();

            movie.Length = 2;
            movie.Ration = 7;

            repo.Update(movie);
            repo.SaveChanges();

            var movieFromDb = repo.GetById(movie.Id);

            Assert.IsNotNull(movieFromDb);
            Assert.AreEqual(2, movieFromDb.Length);
            Assert.AreEqual(7, movieFromDb.Ration);
            Assert.IsTrue(movieFromDb.Id != 0);
        }

        [TestMethod]
        public void ListAllMovieShouldReturnAllMovies()
        {
            var repo = new GenericRepository<Movie>(new MoviesGalleryContext());
            var fakeMovies = new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    Length = 1,
                    Ration = 1
                },
                new Movie()
                {
                    Id = 2,
                    Length = 2,
                    Ration = 2
                },
                new Movie()
                {
                    Id = 3,
                    Length = 3,
                    Ration = 3
                },
            };

            foreach (var fakeMovie in fakeMovies)
            {
                repo.Add(fakeMovie);
                repo.SaveChanges();
            }

            var fakeMovieLengths = fakeMovies.Select(m => m.Length).ToList();
            var movieDbLengths = repo.All().Select(m => m.Length).ToList();

            CollectionAssert.AreEqual(fakeMovieLengths, movieDbLengths);
        }
    }
}
