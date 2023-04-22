namespace Library.CustomAttribute
{
    public class ForeignKeyAttribute : Attribute
    {
        public ForeignKeyAttribute(Type type)
        {
            TheType = type;
        }
        public Type TheType { get; set; }
    }
}
