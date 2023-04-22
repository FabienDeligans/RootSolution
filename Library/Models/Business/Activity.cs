using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Business
{
    public class Activity : Entity
    {
        [Required]
        public string? ActivityNom { get; set; }

        [BsonIgnore]
        public IEnumerable<Inscription>? Inscriptions { get; set; }

        [BsonIgnore]
        public List<GroupDetail>? Groupes { get; set; }
    }
}
