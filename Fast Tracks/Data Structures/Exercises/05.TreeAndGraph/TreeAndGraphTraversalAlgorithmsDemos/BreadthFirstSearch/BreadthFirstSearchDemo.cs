
namespace BreadthFirstSearch
{
    using System;
    using System.Collections.Generic;
    using SoftUni.Collections.Generic;

    public class BreadthFirstSearchDemo
    {
        private static Queue<Tree<int>> nodes = new Queue<Tree<int>>();

        public static void Main()
        {
            var tree = InitializeTree();
            //tree.Print();
            PrintTreeUsingBreadthFirstSearch(tree);
        }

        private static Tree<int> InitializeTree()
        {
            var tree = new Tree<int>(
                7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6)));
            return tree;
        }

        private static void PrintTreeUsingBreadthFirstSearch(Tree<int> node)
        {
            nodes.Enqueue(node);
            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();
                PrintNodeValue(currentNode);
                foreach (var childNode in currentNode.Children)
                {
                    nodes.Enqueue(childNode);
                }
            }

        }

        private static void PrintNodeValue(Tree<int> node)
        {
            Console.WriteLine(node.Value);
        }
    }
}
