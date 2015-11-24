namespace GenericList
{
    using System;
    using System.Linq;

    [Version(1.2)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const byte DefaultCapacity = 16;

        private int count = 0;
        private T[] elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);

                return this.elements[index];
            }
            set
            {
                this.CheckIndex(index);

                if (index >= 0 || index < this.count)
                {
                    this.elements[index] = value;
                }
                else
                {
                    this.elements[index] = value;
                    this.count++;
                }
            }
        }

        public void Add(T value)
        {
            this.CheckForResizing();

            this.elements[this.count] = value;
            this.count++;
        }

        public void Remove(int index)
        {
            this.CheckIndex(index);

            T[] newArr = new T[this.elements.Length];
            for (int i = 0, c = 0; i < this.count; i++)
            {

                if (i == index)
                {
                    continue;
                }

                newArr[c] = elements[i];
                c++;
            }

            this.elements = newArr;
            this.count--;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.count; i++)
            {
                if (Equals(this.elements[i], value)) 
                {
                    return true;
                }
            }

            return false;
        }

        public T Max()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("List is empyt!");
            }

            T maxValue = this.elements[0];
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(maxValue) > 0)
                {
                    maxValue = this.elements[i];
                }
            }

            return maxValue;
            
        }

        public T Min()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("List is empyt!");
            }

            T minValue = this.elements[0];
            for (int i = 0; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(minValue) < 0)
                {
                    minValue = this.elements[i];
                }
            }

            return minValue;

        }

        public void Insert(int index, T elment)
        {
            this.CheckIndex(index);

            T[] newArr = new T[this.elements.Length];
            for (int i = 0; i < this.count + 1; i++)
            {

                if (i == index)
                {
                    newArr[i] = elment;
                }
                else if (i < index)
                {
                    newArr[i] = this.elements[i];
                }
                else
                {
                    newArr[i] = this.elements[i - 1];
                }
            }

            this.elements = newArr;
            this.count++;
        }

        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.count = 0;
        }

        private void Resize()
        {
            T[] newArr = new T[this.elements.Length * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArr[i] = this.elements[i];
            }

            this.elements = newArr;
        }

        private void CheckForResizing()
        {
            if (this.count >= this.elements.Length)
            {
                this.Resize();
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
        }

        public override string ToString()
        {
            if (this.count == 0)
            {
                return "List is empty!";
            }
            return string.Format(string.Join(", ", this.elements.Take(this.count)));
        }
    }
}
