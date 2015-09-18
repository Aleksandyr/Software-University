using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }
        int lastElements = this.Count - count;
        return this.elements.Skip(lastElements).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        this.elements.Sort();
        return this.elements.Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (this.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        this.elements.Sort();
        this.elements.Reverse();
        return this.elements.Take(count);
    }

    public int RemoveAll(T element)
    {
        int count = 0;
        var result = new List<T>();

        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(element) == 0)
            {
                //this.elements.Remove(element);
                count++;
                continue;
            }
            result.Add(this.elements[i]);
        }

        this.elements = result;
        return count;
    }

    public void Clear()
    {
        this.elements = new List<T>();
    }
}
