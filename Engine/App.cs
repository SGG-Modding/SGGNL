using MonoMod;

#pragma warning disable CS0626, CS0114

namespace SGGNL
{
    [MonoModPatch("global::GSGE.App")]
    public class App
    {
        public extern void orig_Initialize();

        public void Initialize()
        {

            ModLoader.LoadMods();

            orig_Initialize();

        }
    }
}
