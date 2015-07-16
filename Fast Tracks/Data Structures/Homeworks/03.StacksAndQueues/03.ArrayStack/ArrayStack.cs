using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ArrayStack
{
    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] elemetns;

        public int Count { get; private set; }

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elemetns = new T[capacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            if (this.Count == this.elemetns.Length)
            {
                Grow();
            }
            this.elemetns[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            var lastElement = this.elemetns[this.Count - 1];
            this.elemetns[this.Count - 1] = default(T);
            this.Count--;
            return lastElement;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            for (int i = this.Count - 1; i >= 0; i--)
            {
                newArray[this.Count - i - 1] = this.elemetns[i];
            }
            return newArray;
        }

        private void Grow()
        {
            T[] newArray = new T[2 * this.elemetns.Length];
            for (int i = 0; i < this.elemetns.Length; i++)
            {
                newArray[i] = this.elemetns[i];
            }

            this.elemetns = newArray;
        }
    }
}
