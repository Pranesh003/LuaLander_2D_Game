# LuaLander 2D 🚀

**LuaLander** is a physics-based 2D space exploration and landing game built with Unity. The objective is to pilot your lander through challenging terrains, manage your fuel, and perform safe landings on designated pads.

## 🎮 Game Mechanics

### 1. Piloting & Physics

Mastering the lander requires careful control of your thrusters and momentum.

- **Thrust**: Apply upward force to counteract gravity.
- **Rotation**: Rotate the lander to navigate obstacles and align for landing.
- **Inertia**: The lander has mass and momentum; you cannot stop instantly!

### 2. Fuel Management ⛽

- You have a limited supply of **Fuel**.
- Every second of thrusting or rotating consumes fuel.
- **Game Over**: If you run out of fuel, you lose control of the lander.
- **Refuel**: Collect **Fuel Canisters** scattered throughout the level to replenish your tank.

### 3. Scoring & Landing 🎯

To complete a level or gain points, you must land on a **Landing Pad**.
A successful landing requires:

- **Soft Landing**: Vertical velocity must be low (don't crash!).
- **Angle**: The lander must be upright (legs down, not upside down).
- **Safe Terrain**: You must hit the pad, not the jagged terrain.

**Score Calculation:**

- **Landing Angle**: The closer to perfectly upright (90°), the higher the score.
- **Landing Speed**: The softer the landing, the higher the bonus.
- **Multipliers**: Different landing pads may offer score multipliers (e.g., x2, x5).
- **Coins**: Collect **Coins** for bonus points (500 pts each).

## 🕹️ Controls

| Action           | Keyboard Input       |
| :--------------- | :------------------- |
| **Thrust (Up)**  | `W` or `Up Arrow`    |
| **Rotate Left**  | `A` or `Left Arrow`  |
| **Rotate Right** | `D` or `Right Arrow` |

## 🛠️ Project Structure

- **`Lander.cs`**: Core logic for ship physics, input handling, fuel consumption, and collision detection.
- **`GameManager.cs`**: Handles global game state, scoring, and UI event subscriptions.
- **`LandingPad.cs`**: Defines landing zones and score multipliers.
- **Assets/**: Contains all sprites, prefabs, materials, and scenes.

## 🚀 Future Roadmap

- [ ] **Lua Scripting Integration**: Allow players to write Lua scripts to automate piloting.
- [ ] **Level Editor**: Create custom maps.
- [ ] **Leaderboards**: Compete for the highest landing scores.

## 📦 Installation & Setup

1.  Clone the repository:
    ```bash
    git clone https://github.com/Pranesh003/LuaLander_2D_Game.git
    ```
2.  Open **Unity Hub**.
3.  Add the project by selecting the `LuaLander` folder.
4.  Open the project (Unity Version 2022.3 or later recommended).
5.  Open the main scene in `Assets/Scenes` and press **Play**.
