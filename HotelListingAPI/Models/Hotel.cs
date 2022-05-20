using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelListingAPI.Models
{
    public class Hotel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string HotelName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

    }
}
