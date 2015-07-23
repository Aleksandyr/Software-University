namespace DepthFirstSearch
{
    using System;
    using SoftUni.Collections.Generic;

    public class DepthFirstSearchDemo
    {
        public static void Main()
        {
            var tree = InitializeTree();
            //tree.Print();
            PrintTreeUsingDepthFirstSearch(tree);
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

        private static void PrintTreeUsingDepthFirstSearch(Tree<int> node)
        {
            foreach (var childNode in node.Children)
            {
                PrintTreeUsingDepthFirstSearch(childNode);
            }

            PrintNodeValue(node);
        }

        private static void PrintNodeValue(Tree<int> node)
        {
            Console.WriteLine(node.Value);
        }
    }
}
