namespace character_system
{
    public class Blessing : Modifier
    {
        public Blessing(string name = "default_blessing", string description = "default_description") : base(name, description) { }
        public override void Modify()
        {
            base.Modify();
        }
        public override bool IsActive()
        {
            return base.IsActive();
        }
    }
}