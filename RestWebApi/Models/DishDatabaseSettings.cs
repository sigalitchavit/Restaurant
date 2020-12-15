using RestWebApi.Interfaces;

namespace RestWebApi.Models
{
    /// <summary>
    /// contains all settings required to communicate with the MongoDB database.
    /// </summary>
    public class DishDatabaseSettings : IDishDatabaseSettings
    {
        public string DishCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
