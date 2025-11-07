using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_sample.Repository.Database.Entity
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("customer_name")]
        public string? CustomerName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}
