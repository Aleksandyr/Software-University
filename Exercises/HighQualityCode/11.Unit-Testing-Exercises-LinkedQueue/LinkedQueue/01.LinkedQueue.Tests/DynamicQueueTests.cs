using System;

namespace LinkedQueue.Tests
{
    using LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class DynamicQueueTests
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void InitQueue()
        {
            //Arange
            this.queue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void EnqueueOneElementShouldReturnCurrectResult()
        {
            const int CurrentElement = 3;
            const int CurrentLength = 1;

            //Act
            this.queue.Enqueue(CurrentElement);

            //Assert
            Assert.AreEqual(CurrentLength, this.queue.Count);
            Assert.AreEqual(CurrentElement, this.queue.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueElementFromEmptyQueueShouldThrowException()
        {
            this.queue.Dequeue();
        }

        [TestMethod]
        public void DequeueOneElementShouldIncreaseCountAndReturnCorrectValue()
        {
            const int FirstElement = 7;
            const int SecondElement = 3;
            const int CurrentLength = 1;

            this.queue.Enqueue(FirstElement);
            this.queue.Enqueue(SecondElement);

            var expectedValue = this.queue.Dequeue();

            Assert.AreEqual(expectedValue, FirstElement);
            Assert.AreEqual(CurrentLength, this.queue.Count);
        }

        [TestMethod]
        public void DequeueSeveralElementsThanDequeueThemShouldReturnCorrectValues()
        {
            const int NumberOfDigits = 3;
            //const int AfterDequeueAllElemntsCount = 0;

            for (int i = 1; i <= NumberOfDigits; i++)
            {
                this.queue.Enqueue(i);
            }

            //You can check counter here!
            //Assert.AreEqual(numberOfDigits, this.queue.Count);

            for (int i = 1; i <= NumberOfDigits; i++)
            {
                Assert.AreEqual(i, this.queue.Dequeue());
            }

            //You can check counter here again if you want!
            //Assert.AreEqual(AfterDequeueAllElemntsCount, this.queue.Count);
        }

        [TestMethod]
        public void EnqueueSeveralElementsAndCheckTheCounter()
        {
            const int NumberOfDigits = 10;

            for (int i = 0; i < NumberOfDigits; i++)
            {
                this.queue.Enqueue(i);
            }

            Assert.AreEqual(NumberOfDigits, this.queue.Count);
        }

        [TestMethod]
        public void EnqueueSeveralElementsThanDequeueSeveralAndCheckTheCounter()
        {
            const int NumberOfDigits = 10;
            const int CounterAfterDequeue = 5;

            for (int i = 0; i < NumberOfDigits; i++)
            {
                this.queue.Enqueue(i);
            }

            Assert.AreEqual(NumberOfDigits, this.queue.Count);

            for (int i = 0; i < CounterAfterDequeue; i++)
            {
                this.queue.Dequeue();
            }

            Assert.AreEqual(CounterAfterDequeue, this.queue.Count);
        }
    }
}
