using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _07.LinkedQueue;

namespace _08.LinkedQueueUnitTests
{
    [TestClass]
    public class LinkedQueueUnitTest
    {
        [TestMethod]
        public void EnqueueAndDequeueElements()
        {
            var linkedQueue = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQueue.Count);

            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(6);
            linkedQueue.Enqueue(7);
            Assert.AreEqual(3, linkedQueue.Count);

            var firstElement = linkedQueue.Dequeue();
            Assert.AreEqual(5, firstElement);
            Assert.AreEqual(2, linkedQueue.Count);
        }

        [TestMethod]
        public void EnqueueAndDequeue1000Elements()
        {
            var linkedQueue = new LinkedQueue<int>();

            for (int i = 0; i <= 1000; i++)
            {
                linkedQueue.Enqueue(i);
                Assert.AreEqual(i + 1, linkedQueue.Count);
            }

            for (int i = 0; i <= 1000; i++)
            {
                Assert.AreEqual(i, linkedQueue.Dequeue());
                Assert.AreEqual(1000 - i, linkedQueue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueFromEmptyLinkedStack()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Dequeue();
        }

        [TestMethod]
        public void LinkedQueueToArray()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(4);

            var testArr = new int[] {1, 2, 3, 4};
            CollectionAssert.AreEqual(testArr, linkedQueue.ToArray());
        }

        public void EmptyLinkedQueueToArray()
        {
            var linkedQueue = new LinkedQueue<DateTime>();
            var testArr = new DateTime[0];

            CollectionAssert.AreEqual(testArr, linkedQueue.ToArray());
        }
    }
}
