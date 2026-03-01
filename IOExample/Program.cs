namespace IOExample;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "example.txt";
        string content = "This is example content.";
        FileWriter fileWriter = new FileWriter();
        //Write data to a file asynchronously
        Task writeTask = fileWriter.WriteToFile(fileName, content);
        writeTask.Wait();//Block until the write operation is completed
        FileReader fileReader = new FileReader();
        //Read data from the file asynchronously
        Task<string> readTask = fileReader.ReadFromFile(fileName);
        readTask.Wait();//Block the current thread until the read operation is completed
        Console.WriteLine($"Read content: {readTask.Result}");
    }
}

class FileWriter
{
    public Task WriteToFile(string filename, string content)
    {
        using (StreamWriter streamWriter = new StreamWriter(filename))
        {
            Task writerTask = streamWriter.WriteAsync(content);
            return writerTask;
        }
    }
}

class FileReader
{
    public Task<string> ReadFromFile(string filename)
    {
        StreamReader streamReader = new StreamReader(filename);
        Task<string> contentTask = streamReader.ReadToEndAsync();
        streamReader.Close();
        return contentTask;
    }
}