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
                    
                }
            }
        }
    }
}