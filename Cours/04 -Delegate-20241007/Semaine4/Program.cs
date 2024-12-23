class Logger
{
    // Declare a delegate for logging methods
    public delegate void LogHandler(string message);
    // Register a method to be called when logging
    public LogHandler Log;
    // Log a message using the registered method
    public void LogMessage(string message)
    {
        Log?.Invoke(message);
    }
}

class ConsoleLogger
{
    public static void LogMessage(string msg)
    {
        Console.WriteLine($"Console Logger: {msg}");
    }
}

class FileLogger
{
        public static void LogMessage(string msg)
        {

        // Set a variable to the Documents path.
        // string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        string docPath = @"D:\Ecole\OneDrive - Haute Ecole Léonard de Vinci\Documents\IPL\Bloc 3\Q1\ProgrammationSpecialisee\DotNet\04 -Delegate-20241007\Semaine4\WriteLines.txt";

        // Append text to an existing file named "WriteLines.txt".
        // using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
        
        using (StreamWriter outputFile = new StreamWriter(docPath, true))
        {
            outputFile.WriteLine($"File Logger: {msg}");
        }
       }
  }