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

#pragma warning disable CS0626, CS0114

namespace Engine.Patches
{
    [MonoModPatch("global::GSGE.App")]
    public class App : global::GSGE.App
    {
        public extern void orig_Initialize();

        public void Initialize()
        {

            ModLoader.LoadMods();

            orig_Initialize();

        }
    }
}
