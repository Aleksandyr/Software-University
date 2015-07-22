using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.PlayWithTrees
{
    class Tree
    {
        private readonly Dictionary<int, Tree> nodeByValue = new Dictionary<int, Tree>();

        public Tree()
        {
            this.Children = new List<Tree>();
        }

        public Tree(int value, params Tree[] children)
        {
            this.Value = value;
            this.Children = new List<Tree>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public int Value { get; set; }
        public Tree Parent { get; set; }
        public IList<Tree> Children { get; set; }

        public Tree GetTreeNodeByVlue(int value)
        {
            if (!this.nodeByValue.ContainsKey(value))
            {
                this.nodeByValue.Add(value, new Tree(value));
            }
            return this.nodeByValue[value];
        }

        public Tree FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public List<Tree> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(
                node => node.Children.Count > 0 && node.Parent != null).OrderBy(node => node.Value).ToList();
            return middleNodes;
        }

        public List<Tree> FindAllLeafs()
        {
            var allLieafs = nodeByValue.Values.Where(
                leaf => leaf.Children.Count == 0 && leaf.Parent != null).OrderBy(leaf => leaf.Value).ToList();
            return allLieafs;
        }

        public List<Tree> FindLongestPath()
        {
            var firstNode = this.FindRootNode();
            var currentElements = new List<Tree>();
            var bestElements = new List<Tree>();
            bestElements = this.FindLongestPath(firstNode, currentElements, bestElements);
            bestElements.Insert(0, firstNode);

            return bestElements;
        }

        public List<List<Tree>> PathsOfSum(int result)
        {
            var firstNode = this.FindRootNode();
            var currentElements = new List<Tree>() { this.FindRootNode() };
            var sumOfElements = new List<List<Tree>>();
            sumOfElements = this.PathsOfSum(firstNode, currentElements, sumOfElements, result);

            return sumOfElements;
        }

        private List<Tree> FindLongestPath(Tree node, List<Tree> elements, List<Tree> bestElements)
        {
            var children = node.Children;
            foreach (var child in children)
            {
                elements.Add(child);
                if (child.Children.Count != 0)
                {
                    bestElements = this.FindLongestPath(child, elements, bestElements);
                }

                if (elements.Count > bestElements.Count)
                {
                    bestElements = elements;
                }

                elements = new List<Tree>();
            }

            return bestElements;
        }

        private List<List<Tree>> PathsOfSum(Tree firstNode, List<Tree> currentElements, List<List<Tree>> sumOfElements, int result)
        {
            var children = firstNode.Children;
            foreach (var child in children)
            {
                currentElements.Add(child);
                if (currentElements.Sum(e => e.Value) == result)
                {
                    sumOfElements.Add(currentElements);
                    currentElements = GetElementsSoFar(child);
                }

                if (child.Children.Count != 0)
                {
                    sumOfElements = this.PathsOfSum(child, currentElements, sumOfElements, result);
                }

                currentElements = GetElementsSoFar(child);
            }

            return sumOfElements;
        }

        private static List<Tree> GetElementsSoFar(Tree child)
        {
            var elements = new List<Tree>();
            var parent = child.Parent;
            while (parent != null)
            {
                elements.Insert(0, parent);
                parent = parent.Parent;
            }

            return elements;
        }
    }
}
