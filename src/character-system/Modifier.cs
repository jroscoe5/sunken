namespace character_system
{
    public class Modifier
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public Modifier(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public virtual void Modify() { }
        public virtual bool IsActive() { return false; }
    }
}