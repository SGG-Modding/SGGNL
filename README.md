# SuperGiant Games .NET Loader (SGGNL)

## How to build
1. create a folder called `Vanilla`
2. drop your game binaries (`*.dll`, `*.exe`) in there (GAMEFOLDER/`x64`). x86 may very well work too but isn't tested yet
3. The game doesn't bundle a file that is required to build, because GamepadBridge.dll lists it as a dependency. Download that from [here](https://files.catbox.moe/6yhtsb.dll) rename it to `Tao.sdl.dll` and place it in the `Vanilla` folder.
4. run build.py with python 3.8 and look in the newly created `Patched` folder
5. copy the `Engine.dll`, `Engine.pdb` and `MMHOOK_Engine.dll` files into the game
6. Enjoy!

TODO: script that when given your game binaries folder does the whole process

## How to create a mod
1. Create a class library (.net framework) using visual studio 2022 and select .net framework 4.5
2. Add `Engine.dll` and `MMHOOK_Engine.dll` to the references
3. For your base class, extend Mod
4. Create a constructor
5. Have fun!

## How to install a mod
1. In the game's `Content` folder, create a folder called `EngineMods`.
2. Place the mod's dll inside
3. Enjoy whatever the mod does
