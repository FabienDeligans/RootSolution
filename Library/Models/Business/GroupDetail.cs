using System.ComponentModel.DataAnnotations;
using Library.CustomAttribute;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.Models.Business
{
    public class GroupDetail : Entity
    {
        [Required]
        [ForeignKey(typeof(Activity))]
        public string? ActivityId { get; set; }

        [BsonIgnore]
        public Activity Activity { get; set; }

        [Required]
        public string? GroupeName { get; set; }

        public List<Seance> Seances { get; set; }

        private TimeSpan _duration;

        [Required]
        public string Duration
        {
            get => _duration.ToString();
            set => TimeSpan.TryParse(value, out _duration);
        }

        [Required]
        public double BasePrice { get; set; }

    }
    public class Seance
    {
        private TimeSpan _start;

        [Required]
        public string Start
        {
            get => _start.ToString();
            set => TimeSpan.TryParse(value, out _start);
        }

        [Required]
        public DayOfWeek Day { get; set; }
    }
}