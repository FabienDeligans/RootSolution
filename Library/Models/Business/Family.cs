using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Business
{
    public class Family : Entity
    {
        [Required]
        public string? Name { get; set; }

        [BsonIgnore]
        public IEnumerable<Parent>? Parents { get; set; }

        [BsonIgnore]
        public IEnumerable<Child>? Children { get; set; }
    }
}
