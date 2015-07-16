using System;

public class BinaryTree<T>
{
    public T Value { get; set; }
    public BinaryTree<T> LeftChield { get; set; }
    public BinaryTree<T> RightChield { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChield = leftChild;
        this.RightChield = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.Write(new string(' ', indent * 2));
        Console.WriteLine(this.Value);
        if (this.LeftChield != null)
        {
            this.LeftChield.PrintIndentedPreOrder(indent + 1);
        }
        if (this.RightChield != null)
        {
            this.RightChield.PrintIndentedPreOrder(indent + 1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.LeftChield != null)
        {
            this.LeftChield.EachInOrder(action);
        }

        action(this.Value);

        if (this.RightChield != null)
        {
            this.RightChield.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (this.LeftChield != null)
        {
            this.LeftChield.EachPostOrder(action);
        }

        if (this.RightChield != null)
        {
            this.RightChield.EachPostOrder(action);
        }

        action(this.Value);
    }
}
