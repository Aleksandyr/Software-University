using System;
using System.Linq;

namespace _07.LinkedQueue
{
    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            }
        }

        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                var newHead = new QueueNode<T>(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("LinkedQueue is empty!");
            }

            var firstElem = this.tail.Value;
            this.tail = this.tail.PrevNode;
           
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }
            
            this.Count--;
            return firstElem;
        }

        public T[] ToArray()
        {
            var arrResult = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arrResult[i] = this.tail.Value;
                this.tail = this.tail.PrevNode;
            }

            return arrResult;
        }
    }
}
