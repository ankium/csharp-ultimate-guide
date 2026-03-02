namespace IOExample;

class Program
{
    async static Task Main(string[] args)
    {
        string fileName = "example.txt";
        string content = "This is example content.";

        FileWriter fileWriter = new FileWriter();
        //Write data to a file asynchronously
        Task writeTask = fileWriter.WriteToFile(fileName, content);
        await writeTask;

        FileReader fileReader = new FileReader();
        //Read data from the file asynchronously
        Task<string> readTask = fileReader.ReadFromFile(fileName);
        string readContent = await readTask;

        Console.WriteLine($"Read content: {readContent}");
    }
}

class FileWriter
{
    public async Task WriteToFile(string filename, string content)
    {
        using (StreamWriter streamWriter = new StreamWriter(filename))
        {
            Task writerTask = streamWriter.WriteAsync(content);
            await writerTask;
        }
    }
}

class FileReader
{
    public async Task<string> ReadFromFile(string filename)
    {
        using(StreamReader streamReader = new StreamReader(filename))
        {
            Task<string> contentTask = streamReader.ReadToEndAsync();
            string content = await contentTask;
            return content;
        }
    }
}