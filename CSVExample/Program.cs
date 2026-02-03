using CSVExample;

class Program
{
    static void Main(string[] args)
    {
        #region DataCSV
        File.WriteAllText(Shared.FilePath,"");
        #endregion

        //Read CSV file in chunks and process each chunk in parallel
        using(StreamReader sr = new StreamReader(Shared.FilePath))
        {
            string? line;
            int lineNumber = 0;

            //Create a list to hold the current chunk
            List<string> chunk = new List<string>();
            
            //Create a list to hold threads
            List<Thread> threads = new List<Thread>();
            int threadCount = 0;
            //Read each line from the CSV file
            while((line = sr.ReadLine()) != null)
            {
                //Skip the iteration if the line is empty
                if(string.IsNullOrEmpty(line))
                    continue;
                //Line is not empty, add it to the chunk and increment line number
                lineNumber++;
                chunk.Add(line);
                //If chunk size is reached, process the chunk in parallel
                if(lineNumber % Shared.ChunkSize == 0)
                {
                    //Increment thread count
                    threadCount++;
                    //Create a copy of the chunk to avoid modification issues
                    List<string> chunkCopy = chunk.Select(x => x).ToList();
                    //Create chunk name
                    string chunkName = $"Chunk-{threadCount}";
                    //Create a new thread to process the chunk
                    Thread thread = new Thread(() =>
                    {
                        InvokeDataProcessor(chunkName,chunkCopy);
                    });
                    //Add thread to the Threads list
                    threads.Add(thread);
                    //Clear the chunk for the next set of lines
                    chunk.Clear();
                }
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
        Console.WriteLine("Processing complete.");//End of Main
    }
    //A method to invoke DataProcessor
    static void InvokeDataProcessor(string chunkName, List<string> chunk)
    {
        //Create an instance of DataProcessor and process the chunk
        DataProcessor processor = new DataProcessor(){chunkName=chunkName,Chunk=chunk};
        processor.ProcessChunk();
        //Print out
    }
}