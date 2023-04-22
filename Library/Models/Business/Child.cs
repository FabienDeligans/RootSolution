using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using Library.CustomAttribute;

namespace Library.Models.Business
{
    public class Child : Entity
    {
        [Required] public string? FirstName { get; set; }

        [Required] public string? LastName { get; set; }

        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? BirthDay { get; set; }

        [Required]
        [ForeignKey(typeof(Family))]
        public string FamilyId { get; set; }

        [BsonIgnore] public Family Family { get; set; }

        [BsonIgnore] public IEnumerable<Inscription>? Inscriptions { get; set; }

        public int Age => GetAge();

        public int GetAge()
        {
            if (BirthDay != null)
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDay.Value.Year;

                if (BirthDay.Value.Date > today.AddYears(-age)) age--;

                return age;
            }
            else
            {
                return 0;
            }
        }
    }
}