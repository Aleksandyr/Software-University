using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using BugTracker.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTracker.Tests
{
    [TestClass]
    public class BugCommentsIntegrationTests
    {
        [TestMethod]
        public void CreateBugWithComments_ListBugComments_ShouldListCommentsCorrectly()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";

            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);

            // Act -> get the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<List<CommentModel>>().Result;

            Assert.AreEqual(2, commentsFromService.Count);

            Assert.IsTrue(commentsFromService[0].Id > 0);
            Assert.AreEqual("Comment 2", commentsFromService[0].Text);
            Assert.AreEqual(null, commentsFromService[0].Author);
            Assert.IsTrue(commentsFromService[0].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));

            Assert.IsTrue(commentsFromService[1].Id > 0);
            Assert.AreEqual("Comment 1", commentsFromService[1].Text);
            Assert.AreEqual(null, commentsFromService[1].Author);
            Assert.IsTrue(commentsFromService[1].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));
        }
    }
}
