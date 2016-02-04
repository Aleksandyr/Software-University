using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T data = default(T), params TreeNode<T>[] children)
        {
            this.root = new TreeNode<T>(data);

            foreach (var chiled in children)
            {
                this.root.Children.Add(chiled);
            }
        }


    }
}
