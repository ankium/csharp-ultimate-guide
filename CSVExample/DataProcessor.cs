using System.Security.Cryptography;

namespace CSVExample
{
    public class DataProcessor
    {
        // Name of the chunk being processed
        public required string ChunkName { get; set; }
        // Lines of data in the chunk
        public required List<string> Chunk { get; set; }
        // Dictionary to hold gender counts
        public Dictionary<string,int> GenderCounts = new Dictionary<string, int>();
        // Method to process the chunk
        public void ProcessChunk()
        {
            foreach (string line in Chunk)
            {
                //Skip the iteration if the line is empty
                if(string.IsNullOrEmpty(line))
                    continue;
                //Split the line by comma to get individual fields
                string[] values = line.Split(',');
                
                if (values.Length >= 5)
                {
                    //Get the gender field (assuming it's the 5th field, index 4)
                    string gender = values[4].Trim().ToLower();
                    //If gender already exists in the dictionary, increment its count
                    if (GenderCounts.ContainsKey(gender))
                    {
                        GenderCounts[gender]++;
                    }
                    else
                    {
                        //If gender does not exist, add it to the dictionary with count 1
                        GenderCounts.Add(gender,1);
                    }
                }
            }
            //Simulate processing time
            Random random = new Random();
            Thread.Sleep(100*random.Next(2,5));
        }
    }
}