# Color Puzzle Dev Kit
_Execution Of The Color Puzzle Concept_

> [!NOTE]
> Please take a look at the [**Documentation**](https://github.com/Kamjam/Color-Puzzle-Dev-Kit/tree/main/Color%20Puzzle%20Dev%20Kit/Assets/Documentation/Color%20Puzzle%20-%20READ%20ME%20with%20Images%20%20Folder).pdf file. It contains an in-depth explanation of Unity entities, scripts, etc.

# Navigation
1. [Assets](#Asset-Breakdown) 

## Asset Breakdown
1. Sprites:
```
Player sprite sheet - created by kit maker using Krita
Door sprite sheet - created by kit maker using Krita
Dye sprite sheet - created by kit maker using Krita
Retro-style Environment Tile sheet + Unity Tile palette - created by kit maker using Krita
```

2. Sounds: [BOOWOMP.mp4](https://youtu.be/KnhXwlFeRP8?si=TvqRCXDzSS8gsaNw)

3. Fonts: [Free Pixel Font: Fibberish (7x9px) by Nathan Scott CC0 License](https://caffinate.itch.io/fibberish)

4. Color Palette (Which was used/Modified for the sprites): ["Grimbo” Color Palette](https://lospec.com/palette-list/grimbo) <br/>
![#dfe6e0](https://placehold.co/15x15/dfe6e0/dfe6e0.png) `#dfe6e0` ![#d9c277](https://placehold.co/15x15/d9c277/d9c277.png) `#d9c277` ![#c17b5c](https://placehold.co/15x15/c17b5c/c17b5c.png) `#c17b5c` <br/>
![#85444a](https://placehold.co/15x15/85444a/85444a.png) `#85444a` ![#85444a](https://placehold.co/15x15/85444a/85444a.png) `#85444a` ![#9ba15f](https://placehold.co/15x15/9ba15f/9ba15f.png) `#9ba15f` <br/>
![#596e47](https://placehold.co/15x15/596e47/596e47.png) `#596e47` ![#38453a](https://placehold.co/15x15/38453a/38453a.png) `#38453a` ![#a9bbcc](https://placehold.co/15x15/a9bbcc/a9bbcc.png) `#a9bbcc` <br/>
![#7687ab](https://placehold.co/15x15/7687ab/7687ab.png) `#7687ab` ![#444a65](https://placehold.co/15x15/444a65/444a65.png) `#444a65` ![#222228](https://placehold.co/15x15/222228/222228.png) `#222228` <br/>
</br>Addons for the kit: <br/>
![#AF7799](https://placehold.co/15x15/AF7799/AF7799.png) `#AF7799` ![#9177AC](https://placehold.co/15x15/9177AC/9177AC.png) `#9177AC` ![#7687ab](https://placehold.co/15x15/AACCCD/AACCCD.png) `#AACCCD`

6. Scriptable Objects: <br/>
Game Color Palette - stores the colors used in the Unity file

7. Save Color Picker Editor Colors: <br/>
 Same as Game Color Palette Asset

8. Animations: (Disabled by default) <br/>
Player_Idle -> Player Animator <br/>
Player_Move -> Player Animator

9. Scenes: <br/>
Start is _0 in build settings_ <br/>
Color Puzzle - Demo is  _1 in build settings_ <br/>
GameOver is _2 in build settings_

10. Documentation: <br/>
```
Asset_List.txt
Game_Concept.txt
Instructor_Reference.txt
README.pdf
```

10. Scripts: (All Variables Should Have Inspector Tooltips) <br/>
```
CameraFollow
CameraSwitcher
CurrentSlot
DontDestroy
Door
Dye
DyeSpawner
GameColorPalette
GameManager
InventoryManager
InventorySlot
LevelTimer
MenuScript
PaintPlayer
PlayerGridMovement
Reset
ToggleInventory  
```

11. Prefabs (In Alphabetical Order):
```
Aqua_Dye
Blue_Dye
Cameras
    Main Camera
    Zoomed Camera
Door
Dye Machine
Dye Slot
    Selection Panel
    Dye Image
    Quantity Text
Game Manager
Green_Dye
Inventory Canvas
    Inventory Grid
        Dye Slot x6
Orange_Dye
Pink_Dye
Player
Pink_Dye
Purple_Dye
Tileset Grid
    Walls
    Grass
    Plants
    Floor
UI Canvas
    UI BG
        Location Text
        Timer Text
        Color Text
        Buttons
            Reset Btn
Yellow_Dye
```
