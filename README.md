# SuperGiant Games .NET Loader (SGGNL)

## How to build
1. Install python 3.8 or later and Visual Studio (2019 or 2022) for .NET 4.5
2. Run `patch.py` with python
3. Provide it with your path to your game binaries (GAMEFOLDER/`x64` or GAMEFOLDER/`x86` etc)
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
