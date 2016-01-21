namespace Tree.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeTest
    {

        [TestMethod]
        public void CreateAnEmptyTreeNode_ShouldHaveDefaultValueAndNoChildren()
        {
            TreeNode<int> tree = new TreeNode<int>();
            const int numberOfChildren = 0;
            var defaultValue = default(int);

            Assert.AreEqual(defaultValue, tree.Value);
            Assert.AreEqual(numberOfChildren, tree.Children.Count);
        }

        [TestMethod]
        public void CreateAnTreeNodeWithValue_ShouldStoreTheValueAndHaveNoChildren()
        {
            var value = 7;
            TreeNode<int> tree = new TreeNode<int>(value);
            const int numberOfChildren = 0;

            Assert.AreEqual(value, tree.Value);
            Assert.AreEqual(numberOfChildren, tree.Children.Count);
        }

        [TestMethod]
        public void CreateTreeNode_ThanAnddingASingleChiledToIt_ShouldAddTheChiled()
        {
            TreeNode<int> tree = new TreeNode<int>();
            const int numberOfChildren = 1;

            tree.Children.Add(new TreeNode<int>(1));

            Assert.AreEqual(numberOfChildren, tree.Children.Count);
        }

        [TestMethod]
        public void CreateTreeNode_ThanAnddingAChildrenToIt_ShouldAddAllChildren()
        {
            TreeNode<int> tree = new TreeNode<int>();
            const int numberOfChildren = 3;

            tree.Children.Add(new TreeNode<int>(1));
            tree.Children.Add(new TreeNode<int>(2));
            tree.Children.Add(new TreeNode<int>(3));

            Assert.AreEqual(numberOfChildren, tree.Children.Count);
        }
    }
}
