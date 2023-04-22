using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.Models
{
    public class Entity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public bool IsDisabled { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreationDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdateDate { get; set; }
    }
}
