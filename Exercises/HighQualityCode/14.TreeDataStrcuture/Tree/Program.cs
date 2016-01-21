namespace Tree
{
    public class Program
    {
        public static void Main()
        {
            TreeNode<int> tree = new TreeNode<int>();
            const int numberOfChildren = 3;

            tree.Children.Add(new TreeNode<int>(1));
            tree.Children.Add(new TreeNode<int>(2));
            tree.Children.Add(new TreeNode<int>(3));

            return;
        }
    }
}
