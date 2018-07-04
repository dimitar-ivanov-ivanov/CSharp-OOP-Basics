namespace StorageMaster.Core
{
    public class StorageOutput
    {
        public StorageOutput(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; }
        
        public int Count { get; }
    }
}
