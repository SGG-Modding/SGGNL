# SuperGiant Games .NET Loader (SGGNL)

## How to build (automatic)
1. Install python 3.8 or later and Visual Studio (2019 or 2022) for .NET 4.5
2. Run `patch.py` with python
3. Provide it with your path to your game binaries (GAMEFOLDER/`x64` or GAMEFOLDER/`x86` etc)
4. Enjoy!

## How to build (manual)
1. create a folder called `Vanilla`
2. drop your game binaries (`*.dll`, `*.exe`) in there (GAMEFOLDER/`x64`). x86 may very well work too but isn't tested yet
3. If the game is Transistor, it doesn't bundle a file that is required to build, because GamepadBridge.dll lists it as a dependency. Download that from [here](https://files.catbox.moe/6yhtsb.dll) rename it to `Tao.sdl.dll` and place it in the `Vanilla` folder.
4. open the project and build it
5. open a command prompt in the folder containing the results
6. run ``MonoMod.exe Engine.dll``
7. remove any instances of `MONOMODDED_` from the names of the files it produced
8. run ``MonoMod.RuntimeDetour.HookGen.exe --private Engine.dll``
9. backup your Engine.dll from the game (rename to Engine.dll.bak or Vanilla_Engine.dll etc.)
10. copy the `Engine.dll` and `MMHOOK_Engine.dll` files into the game
11. Enjoy!

## How to create a mod
1. Create a class library (.net framework) using visual studio 2022 and select .net framework 4.5
2. Add `Engine.dll` and `MMHOOK_Engine.dll` to the references
3. For your base class, extend Mod
4. Have fun!

## How to install a mod
1. In the game's `Content` folder, create a folder called `EngineMods`.
2. Place the mod's dll inside
3. Enjoy whatever the mod does
