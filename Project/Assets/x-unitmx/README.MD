X-UniTMX: A TMX importer for Unity3D
=======================================

X-UniTMX is a TMX file importer to load files from [tiled map editor] into Unity, originally developed for [Twisted Potions: Double Trouble] by [PolCPP]. 

**You can check for more information and some Guides on the [project's wiki](https://bitbucket.org/Chaoseiro/x-unitmx/wiki/Home)**
--------
**[Here you can watch a playlist with all videos created to explain X-UniTMX features](http://www.youtube.com/playlist?list=PLF95zj3GYXXqaXqnaN4RYlVgy3SLnZrz1)**
--------

Documentation
--------
You can access X-UniTMX Doxygen's generated documentation [here](http://chaoseiro.bitbucket.org/docs/X-UniTMX/)

There is also a [Trello board](https://trello.com/b/aIFN7aTk/x-unitmx), where anyone can comment on features and vote for them.

Also, an under construction [forum](http://forum.x-unitmx.org/).

Important
--------
There are 3 branches, *Unity2D*, *trunkDev* and *old*. The *Unity2D* branch contains the "stable" plugin, and is Unity 4.5+. *trunkDev* contains features under development, while *old* contains the plugin version 1.0, for Unity 4.0+, that uses Meshes instead of Sprites.

Installation
------------

   - Either copy X-UniTMX folder into your assets folder or import X-UniTMX v1.6.4.unitypackage as a Unity Package.
   
Examples
------------
To use the Examples included in the package, you will need to:

- Add Example Scenes to Build Settings by selecting the menu *X-UniTMX*->*Add Example Scenes*

- Add the following Sorting Layers to *Edit*->*Project Settings*->*Tags and Layers*->*Sorting Layers*: 
	- BG
	- Background
	- Layer 0
	- Layer 1
	- Layer 2
	- Midground
	- Foreground
	
- Add the following Layer to *Edit*->*Project Settings*->*Tags and Layers*->*Layers*:
	- passthrought
	
- Add the following Tags to *Edit*->*Project Settings*->*Tags and Layers*->*Tags*:
	- PlayerShoot
	- HealDrunks_Blue
	- HealDrunks_Red
	- Branch
		
This is needed as Unity3D does not allow adding these Layers and Scenes at runtime (yet), so you must manually add them...

Now you should be able to open **StartingScene** inside *X-UniTMX Examples* folder and run all scenes with no problems.


Usage
-----

### In Tiled Map editor:

#### Tiles

   - Load your tilemap
   - Paint some tiles in different layers

#### Collisions:
   - Use an Object Layer to automatically generate Unity Colliders (by checking 'Generate Colliders' checkbox).
		- Every object inside this layer will generate a collider!
   - Or use Tiled 0.10 Tile Collisions feature to set per-tile collision objects.

#### Finally

   - Save.
   - Rename the tmx file as xml. Tiled can open maps with xml extension, so you can use it freely and delete the tmx file.

### Unity (Visual)

   - Setup your 2d Scene for 2d sprites (orthographic camera etc).
   - **Important:** Use *Sprite* as your tilesets texture type!
   - Click on *GameObject*->*Create Other*->*Tiled Game Map* or
   - Create an empty GameObject.
		- Now click on *Component*->*Tiled Map*->*Tiled Map Component*
   - On the GameObject inspector you'll select the tilemap XML that you created earlier on Tiled. Then choose the default Material for the Tiles and the inspector will [show a new set of options that look like this]
   - Hit *Import as static Tile Map*

### Unity (Code)
   
   - Setup your 2d Scene for 2d sprites (orthographic camera etc).
   - **Important:** Use *Sprite* as your tilesets texture type!
   - Create a map loader script or modify the *MapLoader* script included inside *X-UniTMX Examples*->*OtherExampleScenes*->*Scripts* folder.
   - Run your project!

*There are also some example assets that you can check if you have any doubts*

*You'll will also have access to all tile map informations, including tiles, tilesets, objects etc, just take a look at the documentation*

  [fontmas]: https://bitbucket.org/fontmas
  [tiled map editor]: http://mapeditor.org/
  [twisted potions: double trouble]: https://bitbucket.org/PolCPP/twisted-potions-double-trouble/
  [PolCPP]: https://bitbucket.org/PolCPP
  [XTiled]: https://bitbucket.org/vinull/xtiled
  [show a new set of options that look like this]: https://bitbucket.org/Chaoseiro/x-unitmx/src/e2142eae84ee4cbcc9dd1570810427c83b2be321/TiledMapComponentScreenshot.PNG?at=Unity2D
  [as in this image]: https://bitbucket.org/Chaoseiro/x-unitmx/src/fee4d5e7b270b3a59d1f9f9eeb92edf84cd09b64/TileSetTextureConfigs.PNG?at=Unity2D