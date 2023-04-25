using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TourAgencyAPIMongodb.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
