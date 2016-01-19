namespace DirectoryTraversal.Tests
{
    public class FakeDirectoryProviderComplexPaths : IDrectoryProvider
    {
        public string[] GetDirectories(string path)
        {
            return new string[]
            {
                @"D:\bin\obj\Assets",
                @"C:\asdasd\asdasd\bin"
            };
        }
    }
}
