namespace Tree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value = default(T))
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public T Value { get; private set; }

        public IList<TreeNode<T>> Children { get; set; }


    }
}
