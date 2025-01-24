# Color Puzzle Dev Kit
_Execution Of The Color Puzzle Concept_

> [!NOTE]
> Please take a look at the [**Documentation**]([url](https://github.com/Kamjam/Color-Puzzle-Dev-Kit/tree/main/Color%20Puzzle%20Dev%20Kit/Assets/Documentation/Color%20Puzzle%20-%20READ%20ME%20with%20Images%20%20Folder)).pdf file. It contains an in-depth explanation of Unity entities, scripts, etc.

# Navigation
1. [Asset Breakdown](#Asset-Breakdown)
2. 

## Asset Breakdown
1. Sprites:
 - Player sprite sheet - created by kit maker using Krita
 - Door sprite sheet - created by kit maker using Krita
 - Dye sprite sheet - created by kit maker using Krita
 - Retro-style Environment Tile sheet + Unity Tile palette - created by kit maker using Krita

2. Sounds:
 - BOOWOMP.mp4 - https://youtu.be/KnhXwlFeRP8?si=TvqRCXDzSS8gsaNw

3. Fonts:
 - Free Pixel Font: Fibberish (7x9px) by nathan scott CC0 License - https://caffinate.itch.io/fibberish

4. Color Palette (Which was used/Modified for the sprites):
    ["Grimbo” Color Palette](https://lospec.com/palette-list/grimbo) <br/>
        `#dfe6e0` `#d9c277` `#c17b5c`
        `#85444a` `#4a363c` `#9ba15f`
        `#596e47` `#38453a` `#a9bbcc`
        `#7687ab` `#444a65` `#222228` <br/>
    Addons for the kit:
       > `#AF7799` `#9177AC` `#AACCCD`

5. Scriptable Objects:
 - Game Color Palette - stores the colors used in the unity file

6. Save Color Picker Editor Colors:
 - Same as Game Color Palette Asset

7. Animations: (Disabled by default)
 - Player_Idle -> Player Animator
 - Player_Move -> Player Animator

8. Scenes:
 - Start is _0 in build settings_
 - Color Puzzle - Demo is  _1 in build settings_
 - GameOver is _2 in build settings_

9. Documentation:
 - Asset_List.txt
 - Game_Concept.txt
 - Instructor_Reference.txt
 - README.pdf

10. Scripts: (All Variables Should Have Inspector Tooltips)
 - CameraFollow
 - CameraSwitcher
 - CurrentSlot
 - DontDestroy
 - Door
 - Dye
 - DyeSpawner
 - GameColorPalette
 - GameManager
 - InventoryManager
 - InventorySlot
 - LevelTimer
 - MenuScript
 - PaintPlayer
 - PlayerGridMovement
 - Reset
 - ToggleInventory  

11. Prefabs (In Alphabetical Order):
- Aqua_Dye
- Blue_Dye
- Cameras
 - ```
   Main Camera
   Zoomed Camera
   ```
 - Door
 - Dye Machine
 - Dye Slot
 -  ```
    Selection Panel
    Dye Image
    Quantity Text
    ```
 - Game Manager
 - Green_Dye
 - Inventory Canvas
  - Inventory Grid
   - Dye Slot x6
  - Orange_Dye
  - Pink_Dye
  - Player
  - Pink_Dye
  - Purple_Dye
  - Tileset Grid
  - ```
    Walls
    Grass
    Plants
    Floor
    ```
   - UI Canvas
   -  UI BG
   -  ```
      Location Text
      Timer Text
      Color Text
      Buttons
      Reset Btn
      ```
   - Yellow_Dye
