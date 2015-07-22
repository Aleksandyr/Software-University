using System.IO;
using System.Linq;
using System.Numerics;

namespace _02.TraverseAndSaveDirectory
{
    class DirectoryTree
    {
        private readonly DirectoryInfo rootFolder;

        public DirectoryTree(DirectoryInfo rootFodler)
        {
            this.rootFolder = rootFodler;
        }

        public long SumOfSize()
        {
            var size = GetSizeOfFolder(this.rootFolder, 0);
            return size;
        }

        private long GetSizeOfFolder(DirectoryInfo folder, long size)
        {
            size += folder.GetFiles().Sum(f => f.Length);
            foreach (var child in folder.GetDirectories())
            {
                size = this.GetSizeOfFolder(child, size);
            }

            return size;
        }
    }
}
