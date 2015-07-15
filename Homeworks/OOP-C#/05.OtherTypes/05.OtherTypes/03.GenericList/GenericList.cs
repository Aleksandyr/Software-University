using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _03.GenericList
{
    public class GenericList<T> where T : IComparable<T>
    {
        private const int defaultLength = 16;

        private T[] elements;
        private int size;

        public GenericList(int capacity = defaultLength)
        {
            this.elements = new T[capacity];
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
                
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                return this.elements[index];
                
            }
            
        }

        public void Add(T element)
        {
            if (this.size == this.elements.Length)
            {
                Resize();
            }
            this.elements[this.size] = element;
            this.size++;
        }


        public void Remove(int index)
        {
            T[] newArr = new T[this.elements.Length];
            for (int i = 0; i < index; i++)
            {
                newArr[i] = this.elements[i];
            }

            for (int i = index + 1; i < this.elements.Length; i++)
            {
                newArr[i - 1] = this.elements[i];
            }

            this.elements = newArr;
            this.size--;
        }

        public void Insert(T element, int index)
        {
            if (index >= this.size)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            if (this.size == this.elements.Length)
            {
                Resize();
            }

            T[] newArr = new T[this.elements.Length];
            for (int i = 0; i < index; i++)
            {
                newArr[i] = this.elements[i];
            }
            newArr[index] = element;
            for (int i = index + 1; i < this.elements.Length; i++)
            {
                newArr[i] = this.elements[i - 1];
            }

            this.elements = newArr;
            this.size++;
        }

        public void Clear()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.elements[i] = default(T);;
            }
            this.size = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.size; i++)
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
            for (int i = 0; i < this.size; i++)
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
            for (int i = 0; i < this.size; i++)
            {
                if (this.elements[i].CompareTo(min) == -1)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.elements[i].CompareTo(element) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string result = string.Join(", ", this.elements.Take(this.size));
            return result;
        }

        private void Resize()
        {
            T[] newArr = new T[this.elements.Length * 2];
            for (int i = 0; i < this.elements.Length; i++)
            {
                newArr[i] = this.elements[i];
            }

            this.elements = newArr;
        }
    }
}