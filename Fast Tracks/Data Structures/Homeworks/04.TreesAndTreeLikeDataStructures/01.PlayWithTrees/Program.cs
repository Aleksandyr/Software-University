using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01.PlayWithTrees
{
    class Program
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var tree = new Tree();
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree parentNode = tree.GetTreeNodeByVlue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree childNode = tree.GetTreeNodeByVlue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var middleNodes = tree.FindMiddleNodes().Select(m => m.Value);
            var leafs = tree.FindAllLeafs().Select(l => l.Value);
            var longestPath = tree.FindLongestPath().Select(l => l.Value);
            var sumOfElemetns = tree.PathsOfSum(pathSum);
            foreach (var sumOfElement in sumOfElemetns)
            {
                var path = sumOfElement.Select(s => s.Value);
                Console.WriteLine(string.Join(", ", path));
            }
        }
    }
}
