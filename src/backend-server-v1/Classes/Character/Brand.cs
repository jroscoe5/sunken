namespace Sunken.Character
{
    public class Brand : Modifier
    {
        public Brand(string name, string description) : base(name, description)
        {
        }
        public override bool IsActive()
        {
            return base.IsActive();
        }
        public override void Modify(object obj)
        {
            base.Modify(obj);
        }
    }
}