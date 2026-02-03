namespace CSVExample
{
    public class DataProcessor
    {
        public string ChunkName { get; set; }
        public List<string> Chunk { get; set; }
        public Dictionary<string,int> GenderCounts = new Dictionary<string, int>();
        public ProcessChunk(string chunkName, List<string> chunk)
        {
            ChunkName = chunkName;
            Chunk = chunk;
        }
    }
}