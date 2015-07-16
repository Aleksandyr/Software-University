using System;
using System.Security.Policy;

namespace _05.LinkedStack
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public T value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
            }
        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("LinkedStack is empty!");
            }
            var first = this.firstNode.value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return first;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = firstNode.value;
                firstNode = firstNode.NextNode;
            }

            return array;
        }

    }
}
