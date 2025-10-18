# Sphere Dev (Unity Game)

A small 2D game inspired by *Red Ball*, where the player controls a rolling sphere and avoids obstacles to reach the finish line.

---

## Overview

Sphere Dev is a beginner-friendly Unity project built to practice physics, collision detection, and basic game design. The player moves a red sphere across a simple obstacle course to reach the end zone.

---

## Features

* Player-controlled sphere movement
* Jumping mechanics
* Basic physics-based obstacles
* Checkpoints and a finish area
* Restart on fall or collision
* Simple UI showing level completion or failure

---

## Tech Stack

* **Engine:** Unity
* **Language:** C#
* **Platform:** PC

---

## Controls

* **W / A / S / D** or **Arrow Keys** – Move
* **Spacebar** – Jump

---

## How to Run

1. Open the project in **Unity Hub**.
2. Click **Open Project** → select the folder `SphereDev/`.
3. In the Unity editor, open `Scenes/MainScene.unity`.
4. Press **Play ▶️** to test the game.
5. To build: **File → Build Settings → Platform (PC/Android)** → **Build**.

---


## How It Works

* The sphere uses **Rigidbody** for physics.
* Movement is applied via **AddForce()** in the `PlayerMovement` script.
* Collisions are detected using **OnCollisionEnter()** or **OnTriggerEnter()**.
* The finish line triggers a win message.
* UI Canvas shows the game state (win/lose/restart).

---


## License

Created for learning purposes. Free to use or modify.
