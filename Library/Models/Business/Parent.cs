using System.ComponentModel.DataAnnotations;
using Library.CustomAttribute;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.Models.Business
{
    public class Parent : Entity
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? PostalCode { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        [Phone]
        public string? PhoneWork { get; set; }

        [Required]
        [EmailAddress]
        public string? Mail { get; set; }

        [Required]
        [ForeignKey(typeof(Family))]
        public string FamilyId { get; set; }

        [BsonIgnore]
        public Family Family { get; set; }
    }
}
