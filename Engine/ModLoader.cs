using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Modding
{
    public class ModLoader
    {

        static List<Mod> modList = new List<Mod>();

        internal static void LoadMods()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string path = Path.Combine(dir, "..", "Content", "EngineMods");

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] files = Directory.GetFiles(path, "*.dll");

            for (int i = 0; i < files.Length; i++)
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
                        modList.Add(mod);
                    }
                }
            }
        }

    }
}
