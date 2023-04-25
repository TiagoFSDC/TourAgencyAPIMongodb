using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TourAgencyAPIMongodb.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public City? city { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
