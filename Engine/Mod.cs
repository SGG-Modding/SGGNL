namespace Modding
{
    public class Mod : IMod
    {
        public virtual string Name => "Undefined";

        public virtual string Version => "Undefined";

        public virtual void Initialize() { }
    }
}
