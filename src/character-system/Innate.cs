namespace character_system
{
    public class Innate : Modifier
    {
        public Innate(string name = "default_innate", string description = "default_description") : base(name, description) { }
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