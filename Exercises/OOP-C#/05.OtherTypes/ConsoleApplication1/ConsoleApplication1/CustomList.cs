using System;
using System.Linq;

namespace ConsoleApplication1
{
    class CustomList<T> where T : IComparable<T>
    {
        private const int DefaultLength = 16;

        private T[] elements;
        private int currIndex;

        public CustomList(int capacity = DefaultLength)
        {
            this.elements = new T[capacity];
            this.currIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.currIndex;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.elements[index]; 
                
            }
            set
            {
                if (index < currIndex)
                {
                    this.elements[index] = value;   
                }
                else
                {
                    this.elements[index] = value;
                    currIndex++;
                }
            }
        }

        public void Add(T element)
        {
            if (currIndex == this.elements.Length)
            {
                Resize();
            }
            this.elements[currIndex] = element;
            currIndex++;
        }

        public void Remove(T element)
        {
            if (currIndex == 0)
            {
                throw new InvalidOperationException();
            }

            int startIndex = 0;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(element) == 0)
                {
                    this.elements[i] = default(T);
                    currIndex --;
                    startIndex++;
                }
            }

            //T[] newArr = new T[this.elements.Length];
            //for (int i = startIndex; i < this.elements.Length; i++)
            //{
            //    newArr[i - startIndex] = this.elements[i];
            //}

            //this.elements = newArr;
        }

        private void Resize()
        {
            T[] newArr = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newArr[i] = elements[i];
            }

            elements = newArr;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public T Max()
        {
            T max = this.elements[0];
            for (int i = 0; i < currIndex; i++)
            {
                if (this.elements[i].CompareTo(max) == 1)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public T Min()
        {
            T min = this.elements[0];
            for (int i = 0; i < currIndex; i++)
            {
                if (this.elements[i].CompareTo(min) == -1)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements);
        }
    }
}