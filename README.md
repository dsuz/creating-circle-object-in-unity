# Creating circle object in Unity
I found many people wanted to create circle object like a donut. So I tried to create Unity Editor Extension which creates circle object using Line Renderer.
The implementation is based on the following youtube movie:

[Draw Circle and place object on circle using Line Renderer](https://www.youtube.com/watch?v=BoDwchoM9Ic)

Plus, this project contains a sample mini-game in which a player shoots ripple lasers which is inspired from Salamander (Konami, 1986).

## How to use
1. Import Assets/Editor/CreateCircleMenu.cs into your project.
1. Select [GameObject] -> [3D Object] -> [Circle...] from menu. It will show a dialog.
1. Click "Create" button in the dialog.
1. "Circle" object will be created in the scene.

## How to play demo
1. Open "default" scene and run.
1. Left click to fire.
1. Use WASD to move around while mashing left click.
1. Drop all blocks from the platform to clear game.
1. Tweak /Assets/Demo/Prefabs/Bullet.  Select the prefab in Project window and change following values in Inspector:
  - Line Renderer
    - Width - How thick the circle
  - Bullet Controller
    - Distance - How far the bullet goes
    - Speed - How fast the bullet goes
    - Start Scale - How big the circle on fire
    - End Scale - How big the circle when bullet goes Distance.

## Web Demo
http://bboydaisuke.wp.xdomain.jp/2017/10/03/editor-extension-making-circle-object-with-unity/
