namespace Library.Models
{
    public interface IEntity
    {
        public string? Id { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
