namespace Modding
{
    public class ModData
    {

        public string name;

        public string version;

        public IMod mod;

        public ModStatus status;

        public string error;

        public ModData(Mod mod, ModStatus status)
        {
            this.mod = mod;
            name = mod.Name;
            version = mod.Version;
            this.status = status;
        }

        public ModData(ModStatus status, string error)
        {
            this.status = status;
            this.error = error;
        }

    }
}
