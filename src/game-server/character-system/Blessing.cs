namespace character_system
{
    public class Blessing : Modifier
    {
        public Blessing(string name = "default_blessing", string description = "default_description") : base(name, description) { }
        public override void Modify(object obj)
        {
            base.Modify(obj);
        }
        public override bool IsActive()
        {
            return base.IsActive();
        }
    }
}