using RecipesApp;

namespace UnitTests
{
    public class Fixture : IDisposable
    {
        public Fixture()
        {
            FileOperations.SetupDirectory();
            FileOperations.SetupFile();
        }

        public void Dispose()
        {
            FileOperations.WriteMessageInFile();
        }
    }
}
