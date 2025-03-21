namespace CosmosDB
{
    public class CosmosDbSettings
    {
        public required string AccountEndpoint { get; set; }
        public required string AccountKey { get; set; }
        public required string DatabaseName { get; set; }
        public required Dictionary<string, string> Containers { get; set; } // Supports multiple containers
    }
}
