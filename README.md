# Transistor.Modding

## How to build
1. create a folder called vanilla
2. drop your transistor binaries in there (TRANSISTOR_FOLDER/x64). x86 may very well work too but isn't tested yet
3. Transistor doesn't bundle a file that is required to build, because GamepadBridge.dll lists it as a dependencie. Download that from [here](https://files.catbox.moe/6yhtsb.dll) and place it in the vanilla folder.
4. open the project and build it
5. open a command prompt in the folder containing the results
6. run ``MonoMod.exe Engine.dll``
7. copy the `MONOMODDED_Engine.dll` file into the folder you just copied the filesd from into vanilla
8. remove the `Engine.dll` or rename it to something like `vanilla_Engine.dll`
9. rename `MONOMODDED_Engine.dll` to `Engine.dll`
10. Enjoy
