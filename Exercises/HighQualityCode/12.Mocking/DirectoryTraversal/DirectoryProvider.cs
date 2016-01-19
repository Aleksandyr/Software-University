using System.IO;

namespace DirectoryTraversal
{
    public class DirectoryProvider : IDrectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            var directories = Directory.GetDirectories(path);

            return directories;
        }
    }
}
