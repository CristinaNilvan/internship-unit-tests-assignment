namespace RecipesApp
{
    public class FileOperations
    {
        private static string _directoryPath;
        private static string _filePath;
        private static FileStream _fileStream;

        public static void SetupDirectory()
        {
            _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "AssignmentFolder");
            Directory.CreateDirectory(_directoryPath);
        }

        public static void SetupFile()
        {
            _filePath = Path.Combine(_directoryPath, "TestsFile.txt");
            _fileStream = File.Create(_filePath);
        }

        public static void WriteMessageInFile()
        {
            using (var streamWriter = new StreamWriter(_fileStream))
            {
                streamWriter.WriteLine("Done testing...");
            }
        }
    }
}
