using Modding.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Modding
{
    public class ModLoader
    {
        static readonly List<string> modNames = new List<string>();
        static readonly Dictionary<string, ModData> modList = new Dictionary<string, ModData>();

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

                    try
                    {
                        if (type.GetConstructor(Type.EmptyTypes)?.Invoke(new object[0]) is Mod mod)
                        {
                            if (modNames.Contains(mod.Name))
                                throw new DuplicateModException("Mod name already registered. Are you trying to load several versions?");

                            modList.Add(mod.Name, new ModData(mod, ModStatus.LOADED));
                            modNames.Add(mod.Name);
                        }
                    }
                    //TODO: log error to future console
                    catch (DuplicateModException ex)
                    {

                    }
                    //TODO: log error to future console
                    catch (Exception ex)
                    {
                        modList.Add(asm.GetName().Name, new ModData(ModStatus.FAILED, "Mod failed to be constructed"));
                    }
                }
            }

            InitializeMods();
        }

        internal static void InitializeMods()
        {
            for(int i = 0; i < modNames.Count; i++)
            {
                try
                {
                    ModData mod = modList[modNames[i]];

                    if (mod.status == ModStatus.LOADED)
                    {

                        mod.mod.Initialize();

                        mod.status = ModStatus.INITIALIZED;
                    }
                }
                //TODO: log error to future console
                catch (Exception ex)
                {
                    modList[modNames[i]].status = ModStatus.FAILED;
                    modList[modNames[i]].error = "Failed to initialize";
                }
            }
        }

    }
}
