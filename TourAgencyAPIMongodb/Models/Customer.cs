using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TourAgencyAPIMongodb.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
