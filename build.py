import os
from pathlib import Path
from shutil import copy, move
from subprocess import run

HERE = Path(os.getcwd())
VANILLA = HERE / "Vanilla"
PATCHED = HERE / "Patched"
BUILD = ("dotnet", "build")
BINARIES = HERE / "Engine/bin/Debug/net452"
MONOMOD = BINARIES / "MonoMod.exe"
HOOKGEN = BINARIES / "MonoMod.RuntimeDetour.HookGen.exe"
GENARGS = ("--private",)
BACKUP = PATCHED / "Engine.dll.bak"
ENGINE = "Engine.dll"
MMHOOK = "MMHOOK_Engine.dll"
MONOMODDED = "MONOMODDED_"
MONO = "Mono"

if not PATCHED.exists():
    os.mkdir(PATCHED)
copy(VANILLA / ENGINE, BACKUP)
    
run(BUILD)
run((MONOMOD, BINARIES / ENGINE))

for path in os.scandir(BINARIES):
    if path.is_file() and MONOMODDED in path.name:
        move(path, BINARIES / path.name.replace(MONOMODDED,""))

run((HOOKGEN,) + GENARGS + (BINARIES / ENGINE,), cwd=BINARIES)

copy(BINARIES / MMHOOK, PATCHED / MMHOOK)
copy(BINARIES / ENGINE, PATCHED / ENGINE)

for path in os.scandir(BINARIES):
    if path.is_file() and path.name[:4] == MONO:
        copy(path, PATCHED / path.name)
