using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03.ArrayStack;

namespace _04.ArrayStackUnitTests
{
    [TestClass]
    public class ArrayStackUnitTest
    {
        [TestMethod]
        public void PushAndPopElement()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);
            
            stack.Push(3);
            Assert.AreEqual(1, stack.Count);

            var element = stack.Pop();
            Assert.AreEqual(3, element);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushAndPop1000Elements()
        {
            var stack = new ArrayStack<int>();
            Assert.AreEqual(0, stack.Count);

            for (int i = 0; i < 1001; i++)
            {
                stack.Push(i);
                Assert.AreEqual(i + 1, stack.Count);
            }
            for (int i = 0; i < 1001; i++)
            {
                Assert.AreEqual(1000 - i, stack.Pop());
                Assert.AreEqual(1000 - i, stack.Count);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack()
        {
            var stack = new ArrayStack<int>();
            stack.Pop();

        }

        [TestMethod]
        public void ToArray()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);

            int[] testArr = new[] {7, -2, 5, 3};
            CollectionAssert.AreEqual(testArr, stack.ToArray());
        }

        [TestMethod]
        public void EmptyStackToArray()
        {
            var stack = new ArrayStack<DateTime>();
            var testArr = new DateTime[0];

            CollectionAssert.AreEqual(testArr, stack.ToArray());
        }
    }
}
