namespace CSVExample;

public class Shared
{
    // Shared configuration and synchronization object
    public static object LockObject { get; set; }
    // File path to the CSV file
    public static string FilePath { get; set; }
    // Size of each chunk to be processed
    public static int ChunkSize { get; set; }
    //
    static Shared()
    {
        LockObject = new object();
        FilePath = "data.csv";
        ChunkSize = 100;
    }
}
