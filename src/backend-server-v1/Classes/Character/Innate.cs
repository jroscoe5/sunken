namespace Sunken.Character
{
    public class Innate : Modifier
    {
        public Innate(string name = "default_innate", string description = "default_description") : base(name, description) { }
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