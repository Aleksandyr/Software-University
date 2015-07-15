using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace _07.ImplementALinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public ListNode<T> nextElement { get; set; }
            public T value { get; private set; }

            public ListNode(T value)
            {
                this.value = value;
            }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        private ListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Index cannot be negative or more than length of array");
                }

                int i = 0;
                ListNode<T> currNode = this.head;
                while (i != index)
                {
                    currNode = currNode.nextElement;
                    i++;
                }

                return currNode;
            }
        }

        public void Add(T value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(value);
            }
            else
            {
                var newTail = new ListNode<T>(value);
                this.tail.nextElement = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty collection!");
            }

            ListNode<T> removed = this[index];
            ListNode<T> previous = null;

            if (removed == this.tail)
            {
                tail = this[index - 1];
            }

            if (removed != this.head)
            {
                previous = this[index - 1];
                previous.nextElement = removed.nextElement;
                if (previous == this.head)
                {
                    this.head = previous;
                }
            }
            else
            {
                this.head = removed.nextElement;
            }
        }

        public int FirstIndexOf(T value)
        {
            var currNode = this.head;
            int index = 0;
            foreach (T currElement in this)
            {
                currNode = currNode.nextElement;
                if (currElement.Equals(value))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        public int LastIndexOf(T value)
        {
            var currNode = this.head;
            int index = 0;
            int lastIndex = -1;
            foreach (T currElem in this)
            {
                if (currElem.Equals(value))
                {
                    lastIndex = index;
                }
                index++;
            }
            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currNode = this.head;
            while (currNode != null)
            {
                yield return currNode.value;
                currNode = currNode.nextElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
