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
BACKUP = ".bak"
ENGINE = "Engine"
ENGINEDLL = "Engine.dll"
ENGINEMM = "Engine.mm.dll"
MMHOOK = "MMHOOK_Engine.dll"
MONOMODDED = "MONOMODDED_"
MONO = "Mono"
EXE = ".exe"
GAMEEXES = {"Bastion.exe"}
GAMEDATA = ENGINEDLL
SGGNL = "SGGNL.dll"

if not PATCHED.exists():
    os.mkdir(PATCHED)
if m := tuple(filter(lambda x: (VANILLA / x).exists(), GAMEEXES)):
    GAMEDATA = m[0]
    
BACKUPDATA = GAMEDATA + BACKUP
VBACKUPDATA = VANILLA / BACKUPDATA
VGAMEDATA = VANILLA / GAMEDATA
if VBACKUPDATA.is_file():
    copy(VBACKUPDATA, VGAMEDATA)
copy(VGAMEDATA, PATCHED / BACKUPDATA)
    
run(BUILD)
for path in os.scandir(VANILLA):
    if path.is_file():
        copy(path, BINARIES / path.name)
if GAMEDATA in GAMEEXES:
    game = GAMEDATA.replace(EXE, "")
    copy(BINARIES / ENGINEMM, BINARIES / ENGINEMM.replace(ENGINE, game))
    MMHOOK = MMHOOK.replace(ENGINE, game)
run((MONOMOD, BINARIES / GAMEDATA))

for path in os.scandir(BINARIES):
    if path.is_file() and MONOMODDED in path.name:
        move(path, BINARIES / path.name.replace(MONOMODDED,""))

run((HOOKGEN,) + GENARGS + (BINARIES / GAMEDATA,), cwd=BINARIES)

copy(BINARIES / MMHOOK, PATCHED / MMHOOK)
copy(BINARIES / GAMEDATA, PATCHED / GAMEDATA)

for path in os.scandir(BINARIES):
    if path.is_file() and (path.name == SGGNL or path.name[:4] == MONO):
        copy(path, PATCHED / path.name)
