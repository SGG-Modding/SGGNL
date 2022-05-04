import os
import sys
from pathlib import Path
from shutil import copy, move
from subprocess import run
import urllib.request

HERE = Path(os.getcwd())
VANILLA = HERE / "Vanilla"
PATCHED = HERE / "Patched"
TYPES = {".exe", ".dll", ".bak"}

NEEDTAO = {"Transistor"}
TAOURL = "https://files.catbox.moe/6yhtsb.dll"
TAOFILE = VANILLA / "Tao.sdl.dll"

GAME = None

def gamestr(game):
    if game.name[0] == 'x':
        return f"{game.parent.name}'s {game.name}"
    return f"{game.name}'s"

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
    print(f"Patching {gamestr(GAME)} binaries...")

if not VANILLA.exists():
    os.mkdir(VANILLA)

for path in os.scandir(GAME):
    if path.is_file() and (t == path.name[-len(t):] for t in TYPES):
        copy(path, VANILLA / path.name)

if GAME.parent.name in NEEDTAO and not TAOFILE.exists():
    with open(TAOFILE, "wb") as file:
        file.write(urllib.request.urlopen(TAOURL).read())

from build import *

for path in os.scandir(PATCHED):
    if path.is_file():
        copy(path, GAME / path.name)

if len(sys.argv) == 1:
    input(f"Patched {gamestr(GAME)} binaries! Press ENTER to exit program...")
