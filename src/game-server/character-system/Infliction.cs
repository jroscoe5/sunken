namespace character_system
{
    public class Infliction : Modifier
    {
        public Infliction(string name = "default_infliction", string description="default_description") : base(name, description)
        {
        }
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