using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _05.LinkedStack;

namespace _06.LinkedStackTests
{
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void PushAndPopElement()
        {
            LinkedStack<int> linkedStack = new LinkedStack<int>();
            Assert.AreEqual(0, linkedStack.Count);

            linkedStack.Push(3);
            Assert.AreEqual(1, linkedStack.Count);

            var element = linkedStack.Pop();
            Assert.AreEqual(3, element);
            Assert.AreEqual(0, linkedStack.Count);
        }

        [TestMethod]
        public void PushAndPop1000Elements()
        {
            var linkedStack = new LinkedStack<int>();
            for (int i = 0; i <= 1000; i++)
            {
                linkedStack.Push(i);
                Assert.AreEqual(i + 1, linkedStack.Count);
            }

            for (int i = 0; i <= 1000; i++)
            {
                Assert.AreEqual(1000 - i, linkedStack.Pop());
                Assert.AreEqual(1000 - i, linkedStack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyLinkedStack()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Pop();
        }

        [TestMethod]
        public void ToArray()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(1);
            linkedStack.Push(2);
            linkedStack.Push(3);
            linkedStack.Push(4);

            var testArr = new int[] {4, 3, 2, 1};
            CollectionAssert.AreEqual(testArr, linkedStack.ToArray());
        }

        public void EmptyLinkedStackToArray()
        {
            var linkedStack = new LinkedStack<DateTime>();
            var testArr = new DateTime[0];

            CollectionAssert.AreEqual(testArr, linkedStack.ToArray());
        }
    }
}
