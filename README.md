# Smile-Be-Head (Unity 2D Prototype)

This project is a 2D top-down shooter prototype built in Unity. The goal of this prototype is to demonstrate strong fundamentals in gameplay programming, clean architecture, and scalable system design rather than visual polish. The project was completed as part of a rapid prototyping test focused on core gameplay mechanics.

## 🎮 Core Gameplay Mechanics Implemented

### Player Controller

- Smooth 8-directional movement using keyboard input
- Mouse-based aiming
- Separation of player visuals and physics for clean control

> The player aims using the mouse position. Every frame, the weapon pivot rotates to face the mouse in world space, so the weapon always points toward the cursor.

### Shooting & Weapons

- Left-click shooting
- Modular weapon system using ScriptableObjects
- Implemented weapon types:
  - Pistol (single shot)
  - Shotgun (multiple bullets with spread)
  - Assault Rifle (continuous fire)
- Fire rate handled using a cooldown-based timer
  > Shooting is handled through a weapon controller. The player does not spawn bullets directly. Instead, the controller triggers a weapon defined using a ScriptableObject, which decides how the weapon fires. This allows different weapons like a pistol, shotgun, or assault rifle to behave differently using data such as fire rate, bullet count, and spread.

### Enemies

- Enemies spawn in increasing waves from predefined spawn points
- Each wave starts only after the previous wave is cleared
- Enemies move toward the player using simple steering-based pathfinding
- Enemy behavior and stats are data-driven

> Enemies are spawned using a dedicated spawner system.  
> The spawner starts a wave by spawning a fixed number of enemies from predefined spawn points around the level.
> Each enemy notifies the spawner when it dies using an event.  
> The spawner keeps track of how many enemies are alive, and once all enemies in the current wave are defeated, it automatically starts the next wave with an increased enemy count.

### Combat & Interaction

- Bullet-based combat
- Bullets damage enemies on impact
- Bullets are blocked by obstacles
- Enemies deal continuous contact damage to the player
- Enemies cannot damage each other
- Health system for both player and enemies
- Solid obstacles block:
  - Player movement
  - Enemy movement
  - Player bullets
- Implemented using layer-based collision handling

> Damage is handled using a common damage interface.  
> Bullets detect collisions using trigger colliders and apply damage to anything that implements the damage interface, such as enemies.
> Enemies deal damage to the player using contact-based damage. While an enemy is touching the player, it applies damage at fixed time intervals, and stops immediately when contact ends. Enemies are prevented from damaging each other by explicitly targeting the player’s health component.

### Game Loop

- Start screen with "Start Game" button
- Gameplay state
- Game Over screen when player health reaches zero
- Restart functionality via scene reload

> The game loop is controlled by a central GameManager using a simple state system. The game starts in a main menu state. When the player presses the start button, the game switches to the playing state, which enables the player and enemy spawner and resumes time.
> During gameplay, if the player’s health reaches zero, a death event is triggered and the GameManager switches the game to a game over state. In this state, gameplay stops and the game over UI is shown. Restarting the game simply reloads the scene, which resets all gameplay systems cleanly.

---

## 🧠 Key Systems & Techniques Used

- Object-Oriented Programming (OOP)
- ScriptableObjects for data-driven design
- Interfaces for combat interaction
- Event-driven architecture
- Composition over inheritance
- Finite State Machine (FSM) for game flow
- Layer-based collision handling
- Rigidbody2D-based physics movement

---

## 🏗 Project Structure (High-Level)

- Core
  - GameManager
  - GameState
  - EnemyWaveSpawner
- Player
  - PlayerMovement
  - PlayerAim
  - PlayerHealth
  - WeaponController
- Weapons
  - WeaponData (ScriptableObjects)
  - FireMode
  - WeaponType
  - Weapon behavior scripts
- Enemies

  - EnemyController
  - EnemyData
  - EnemyMovement
  - EnemyHealth
  - EnemyDamage

- Combat
  - Bullet
  - IDamageable
  - IWeapon
- UI
  - UIController

---

## ▶ How to Play

- Move: WASD / Arrow Keys
- Aim: Mouse cursor
- Shoot: Left Mouse Button
- Start Game: Click "Start Game"
- Restart: Click "Restart" on Game Over screen

---

## 📝 Notes

- Visuals and animations were kept minimal to focus on gameplay logic
- The architecture is intentionally designed to be extendable (more weapons, enemy types, abilities)

## 📌 Author

Built as part of a Unity gameplay programming assessment for **Menstrupedia**.
