# Transistor.Modding

## How to build
1. create a folder called vanilla
2. drop your transistor binaries in there (TRANSISTOR_FOLDER/x64). x86 may very well work too but isn't tested yet
3. Transistor doesn't bundle a file that is required to build, because GamepadBridge.dll lists it as a dependencie. Download that from [here](https://files.catbox.moe/6yhtsb.dll) and place it in the vanilla folder.
4. open the project and build it
5. open a command prompt in the folder containing the results
6. run ``MonoMod.exe Engine.dll``
7. run ``MonoMod.RuntimeDetour.HookGen.exe --private MONOMODDED_Engine.dll``
8. copy the `MONOMODDED_Engine.dll`, `MONOMODDED_Engine.pdb` and `MMHOOK_MONOMODDED_Engine.dll` files into the folder you just copied the filesd from into vanilla
9. remove the `Engine.dll` or rename it to something like `vanilla_Engine.dll`
10. rename remove `MONOMODDED_` from the files you copied to the folder
11. Enjoy!

Part 6, 7 and 10 will be automated soon (hopefully)

## How to create a mod
1. Create a class library (.net framework) using visual studio 2022 and select .net framework 4.5
2. Add `Engine.dll` and `MMHOOK_Engine.dll` to the references
3. For your base class, extend Mod
4. Create a constructor
5. Have fun!

## How to install a mod
1. In the folder containing the game exe, create a folder called `mods`.
2. Place the mod's dll inside
3. Enjoy whatever the mod does
