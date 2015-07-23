using System.Linq;

namespace DepthFirstSearchIterative
{
    using System;
    using System.Collections.Generic;
    using SoftUni.Collections.Generic;

    public class DepthFirstSearchIterativeDemo
    {
        private static Stack<Tree<int>> nodes = new Stack<Tree<int>>();

        public static void Main()
        {
            var tree = InitializeTree();
            //tree.Print();

            // Note that the recursive and iterative DFS provide different orderings of the nodes
            // but they are both valid
            PrintTreeUsingIterativeDepthFirstSearch(tree);
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

        private static void PrintTreeUsingIterativeDepthFirstSearch(Tree<int> node)
        {
            nodes.Push(node);
            while (nodes.Count > 0)
            {
                var currentNode = nodes.Pop();
                PrintNodeValue(currentNode);
                foreach (var childNode in currentNode.Children)
                {
                    nodes.Push(childNode);
                }
            }

        }

        private static void PrintNodeValue(Tree<int> node)
        {
            Console.WriteLine(node.Value);
        }   
    }
}
