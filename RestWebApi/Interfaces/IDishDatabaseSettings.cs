namespace RestWebApi.Interfaces
{
    /// <summary>
    /// Interface for all settings required for the layer communicating with the MongoDB DAL layer.
    /// </summary>
    public interface IDishDatabaseSettings
    {
        public string DishCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}