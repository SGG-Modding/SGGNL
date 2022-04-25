import os
import sys
from pathlib import Path
from shutil import copy
from subprocess import run

HERE = Path(os.getcwd())
VANILLA = HERE / "Vanilla"
PATCHED = HERE / "Patched"
TYPES = {".exe", ".dll"}

GAME = None

if len(sys.argv) > 1:
    s = sys.argv[1]
    GAME = Path(s)
    if not Game.exists():
        raise FileNotFoundError(s)
else:
    GAME = Path(input("Enter path to game's binaries folder (x64, x86 etc):"))
    while not GAME.exists():
        s = input("Invalid Path! Press ENTER to exit progam or try another path:")
        if not s:
            exit()
        GAME = Path(s)
    print(f"Patching {GAME.parent.name}'s {GAME.name} binaries...")

if not VANILLA.exists():
    os.mkdir(VANILLA)

for path in os.scandir(GAME):
    if path.is_file() and path.name[:-4] in TYPES:
        copy(path, VANILLA / path.name)
    
import build

for path in os.scandir(PATCHED):
    if path.is_file():
        copy(path, GAME / path.name)

if len(sys.argv) == 1:
    input(f"Patched {GAME.parent.name}'s {GAME.name} binaries! Press ENTER to exit program...")
