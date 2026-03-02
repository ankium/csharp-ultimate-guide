namespace IOExample;

class Program
{
    async static Task Main(string[] args)
    {
        string fileName = "example.txt";
        string content = "This is example content.";

        FileWriter fileWriter = new FileWriter();
        //Write data to a file asynchronously
        await fileWriter.WriteToFile(fileName, content);

        FileReader fileReader = new FileReader();
        //Read data from the file asynchronously
        string readContent = await fileReader.ReadFromFile(fileName);

        Console.WriteLine($"Read content: {readContent}");
    }
}

class FileWriter
{
    public async Task WriteToFile(string filename, string content)
    {
        using (StreamWriter streamWriter = new StreamWriter(filename))
        {
            await streamWriter.WriteAsync(content);
        }
    }
}

class FileReader
{
    public async Task<string> ReadFromFile(string filename)
    {
        using(StreamReader streamReader = new StreamReader(filename))
        {
            string content = await streamReader.ReadToEndAsync();
            return content;
        }
    }
}