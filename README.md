# SuperGiant Games .NET Loader (SGGNL)

## How to build
1. run 'patch.py' with python 3.8 or later
2. provide it with your path to your game binaries (GAMEFOLDER/`x64` or GAMEFOLDER/`x86` etc)
3. If the game is Transistor, it doesn't bundle a file that is required to build, because GamepadBridge.dll lists it as a dependency. Download that from [here](https://files.catbox.moe/6yhtsb.dll), rename `6yhtsb.dll` it to `Tao.sdl.dll` and place it in the `Vanilla` folder, then repeat step 2.
4. Enjoy!

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
