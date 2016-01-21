using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T data = default(T))
        {
            this.root = new TreeNode<T>(data);
        }
    }
}
