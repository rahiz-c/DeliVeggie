namespace Infrastructure.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName:Attribute
    {
        public CollectionName(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            Name = value;
        }
        public virtual string Name { get; set; }
    }
}
