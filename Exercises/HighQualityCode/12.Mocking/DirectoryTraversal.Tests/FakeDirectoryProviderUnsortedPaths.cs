namespace DirectoryTraversal.Tests
{
    public class FakeDirectoryProviderUnsortedPaths : IDrectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[]
            {
               "bin",
               "obj",
               "bbin",
               "assets",
               "Assets"
            };
        }
    }
}
