using System;

namespace DynamicList.Tests
{
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        const int lengthOfElements = 10;

        private DynamicList<int> linkedList;

        [TestInitialize]
        public void InitilizeDynamicList()
        {
            this.linkedList = new DynamicList<int>();
        }

        [TestMethod]
        public void CreateEmptyListShouldBeWithZeroCounter()
        {
            const int currentLength = 0;

            Assert.AreEqual(currentLength, this.linkedList.Count, "Incorrect counter");
        }

        [TestMethod]
        public void ChangeValueOfGivenPositionShoudChangeTheValueAtThisPosition()
        {
            const int expectedValue = 9;
            
            this.linkedList.Add(2);
            this.linkedList.Add(-10);
            this.linkedList[0] = 9;

            Assert.AreEqual(this.linkedList[0], expectedValue, "This value is not equal to the expected change.");
        }

        [TestMethod]
        [ExpectedException(
            typeof(ArgumentOutOfRangeException),
            "Indexer didn't throw correct exception, when invalid index was setted",
            AllowDerivedTypes = true)]
        public void IndexerShouldThrowExceptionWhenSettingElementOnInvalidPosition()
        {
            this.linkedList[1] = 5;
        }

        [TestMethod]
        public void AddingMoreElementsShouldIncreaseTheElemetsCount()
        {
            int expectedCountValue = 3;

            this.linkedList.Add(2);
            this.linkedList.Add(-10);
            this.linkedList.Add(5);
            Assert.AreEqual(expectedCountValue, this.linkedList.Count, "The list count is not equal to the number of added elements.");
        }

        [TestMethod]
        public void AddOneElementShouldIncreaseCountAndReturnCorrectValue()
        {
            const int currentElement = 10;
            const int currentLength = 1;

            this.linkedList.Add(currentElement);

            Assert.AreEqual(currentElement, this.linkedList[0], "Incorrect value");
            Assert.AreEqual(currentLength, this.linkedList.Count, "Incorrect counter");
        }

        [TestMethod]
        public void AddOneElementThanDeleteElementThatNotExistShouldReturnNegativeValue()
        {
            const int currentElement = 10;
            const int elementThatNotExist = 4;
            const int valueThatShouldReturn = -1;
            const int currentLength = 1;

            this.linkedList.Add(currentElement);

            int deletedValueResult = this.linkedList.Remove(elementThatNotExist);

            Assert.AreEqual(valueThatShouldReturn, deletedValueResult, "Incorrect delete return value");
            Assert.AreEqual(currentLength, this.linkedList.Count, "Incorrect counter");
        }

        [TestMethod]
        public void AddOneElementThanDeleteItShouldReturnZeroAndDecreaseTheCounter()
        {
            const int currentElement = 10;
            const int valueThatShouldReturn = 0;
            const int currentLength = 0;

            this.linkedList.Add(currentElement);

            int deletedValueResult = this.linkedList.Remove(currentElement);

            Assert.AreEqual(valueThatShouldReturn, deletedValueResult, "Incorrect delete return value");
            Assert.AreEqual(currentLength, this.linkedList.Count, "Incorrect counter");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddElementsThanDeleteElementWithIncorrectIndexShouldThrowAnException()
        {
            const int incorrectIndex = 15;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i);
            }

            this.linkedList.RemoveAt(incorrectIndex);
        }

        [TestMethod]
        public void AddElementsThanDeleteElementWithCorrectIndexShouldReturnDeletedValue()
        {
            const int correctIndex = 5;
            const int expectedDeleteValue = 5;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i);
            }

            int deletedValue = this.linkedList.RemoveAt(correctIndex);

            Assert.AreEqual(expectedDeleteValue, deletedValue, "Incorrect deleted value");
        }

        [TestMethod]
        public void AddElementsThanDeleteSomeOfThemShouldReturnCorrectCounter()
        {
            const int lenghtOfDeletedValues = 5;
            const int correctCounter = 5;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i);
            }

            for (int i = 0; i < lenghtOfDeletedValues; i++)
            {
                this.linkedList.RemoveAt(i);
            }

            Assert.AreEqual(correctCounter, this.linkedList.Count, "Incorrect counter");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldRemoveElementFromListAndReorderList()
        {
            const int expectedValue = -6;

            this.linkedList.Add(13);
            this.linkedList.Add(-6);
            this.linkedList.Add(5);

            int number = this.linkedList.RemoveAt(0);

            Assert.AreEqual(expectedValue, this.linkedList[0], "Does not reorder the elements.");
        }

        [TestMethod]
        public void AddElementsGetIndexOfOnElementShouldReturnCorrectIndex()
        {
            const int currentDigit = 10;
            const int indexOfCurrentElement = 5;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i * 2);
            }

            int getedIndex = this.linkedList.IndexOf(currentDigit);

            Assert.AreEqual(indexOfCurrentElement, getedIndex, "Incorrect geted index");
        }

        [TestMethod]
        public void AddElementsGetIncorrectIndexOfOnElementShouldReturnNegativeValue()
        {
            const int incorrectDigit =  5;
            const int expectedResult = -1;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i * 2);
            }

            int getedIndex = this.linkedList.IndexOf(incorrectDigit);

            Assert.AreEqual(expectedResult, getedIndex, "Incorrect geted index");
        }

        [TestMethod]
        public void AddElementsCheckIfElementIsExistShouldReturnTrue()
        {
            const int currentElement = 5;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i);
            }

            bool isContains = this.linkedList.Contains(currentElement);

            Assert.IsTrue(isContains, "Incorrect contains element!");
        }

        [TestMethod]
        public void AddElementsCheckIfIncorrectElementExistShouldReturnFalse()
        {
            const int incorrectElement = 100;

            for (int i = 0; i < lengthOfElements; i++)
            {
                this.linkedList.Add(i);
            }

            bool isContains = this.linkedList.Contains(incorrectElement);

            Assert.IsFalse(isContains, "Incorrect contains element!");
        }
    }
}
