namespace API.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}