using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestWebApi.Models
{
    /// <summary>
    /// This is the data model of the Dish type.
    /// </summary>
    public class Dish
    {
        #region Constructors

        public Dish(){}

        public Dish(string name, string shortDesc, decimal price, Category category, TimeOfDay availability,
            bool active, int waitingTime)
        {
            Name = name;
            ShortDesc = shortDesc;
            Price = price;
            Category = category;
            Availability = availability;
            Active = active;
            WaitingTime = waitingTime;
        }

        #endregion

        #region public Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public decimal Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TimeOfDay Availability { get; set; } 

        public bool Active { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        public int WaitingTime { get; set; }

        #endregion
    }
}
