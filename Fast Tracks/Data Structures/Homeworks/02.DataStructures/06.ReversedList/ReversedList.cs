using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

namespace _06.ReversedList
{
    class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCount = 16;

        private T[] elements;
        private int size;

        public ReversedList(int capacity = DefaultCount)
        {
            this.elements = new T[capacity];
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size - 1;
            }
            
        }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > this.size - 1)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range!");
                }
                return this.elements[(this.size - 1) - index];
            }
        }

        public void Add(T elem)
        {
            if (this.size >= this.elements.Length)
            {
                Resize();
            }
            this.elements[size] = elem;
            size++;
        }

        public void Remove(int index)
        {
            T[] newArr = new T[this.size];
            index = (this.size - 1) - index;
            Console.WriteLine("Index: " + index);
            if (index >= this.size || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index cannot be negative or more than array length!");
            }
            for (int i = 0; i < index; i++)
            {
                newArr[i] = elements[i];
            }

            for (int i = index + 1; i < this.size; i++)
            {
                newArr[i - 1] = elements[i];
            }
            this.elements = newArr;
            this.size--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.size - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            T[] revArr = new T[this.size];
            for (int i = this.size - 1; i >= 0; i--)
            {
                revArr[(this.size - 1) - i] = elements[i];
            }

            string result = string.Join(", ", revArr.Take(this.size));
            return result;
        }

        private void Resize()
        {
            T[] newArr = new T[this.size * 2];
            for (int i = 0; i < this.size; i++)
            {
                newArr[i] = elements[i];
            }

            this.elements = newArr;
        }
    }
}
