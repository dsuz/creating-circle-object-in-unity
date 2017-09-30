# ripple_lazer_demo
Demo for describing how to implement ripple lasers like in Salamander (Konami, 1986)

Line Renderer is involved to draw circle, which is desribed in the following youtube movie:

[Draw Circle and place object on circle using Line Renderer](https://www.youtube.com/watch?v=BoDwchoM9Ic)

## Quick Start
1. Clone/download this repository.
1. Open "default" scene and run.
1. Left click to fire.
1. Use WASD to move around while mashing left click.
1. Tweak /Assets/Resources/Prefabs/Circle.  Select the prefab in Project window and change following values in Inspector:
  - Drawing Circle Controller
    - Vertex Count - The bigger values, the smoother circle
    - Line Width - How thick the circle
  - Bullet Controller
    - Distance - How far the bullet goes
    - Speed - How fast the bullet goes
    - Start Radius - How big the circle on fire
    - End Radius - How big the circle when bullet goes Distance.
