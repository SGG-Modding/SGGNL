using GSGE;
using MonoMod;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#pragma warning disable 1591
#pragma warning disable CS0108, CS0626

namespace Engine.Patches
{
    [MonoModPatch("global::GSGE.App")]
    public class App : global::GSGE.App
    {
        public extern void orig_Initialize();

        public void Initialize()
        {

            var dir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string[] files = Directory.GetFiles(Path.Combine(dir,"mods"), "*.dll");

            for(int i = 0; i < files.Length; i++)
            {
                Assembly asm = Assembly.LoadFrom(files[i]);

                Type[] types = asm.GetTypes();

                for (int j = 0; j < types.Length; j++) 
                {
                    Type type = types[j];
                    if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(Mod)))
                        continue;

                    if (type.GetConstructor(Type.EmptyTypes)?.Invoke(new Object[0]) is Mod mod)
                    {

                    }
                }
            }

            orig_Initialize();

        }
    }
}
