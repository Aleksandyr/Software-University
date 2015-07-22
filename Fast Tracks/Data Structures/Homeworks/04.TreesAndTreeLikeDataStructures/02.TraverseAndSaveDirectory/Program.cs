using System;
using System.IO;

namespace _02.TraverseAndSaveDirectory
{
    class Program
    {
        static void Main()
        {
            var rootFolde = new DirectoryInfo(@"..\..\..\");
            Console.WriteLine(rootFolde.FullName);
            var directoryTree = new DirectoryTree(rootFolde);
            Console.WriteLine("{0} KB", directoryTree.SumOfSize() / 1024);
        }
    }
}
