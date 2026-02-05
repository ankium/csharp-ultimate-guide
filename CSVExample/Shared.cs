namespace CSVExample;

public class Shared
{
    // File path to the CSV file
    public static string FilePath { get; set; }
    // Size of each chunk to be processed
    public static int ChunkSize { get; set; }
    // Maximum number of concurrent threads
    public static int MaxConcurrentThreads { get; set; }
    // Mutex for synchronizing access to shared resources
    public static Mutex Mutex { get; set; } 
    static Shared()
    {
        FilePath = "data.csv";
        ChunkSize = 100;
        MaxConcurrentThreads = 3;
        Mutex = new Mutex();
    }
}
