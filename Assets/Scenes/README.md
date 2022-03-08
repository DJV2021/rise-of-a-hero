# Scenes

* **StartScreen ➡️ GameScreen_Out** (StartScreenManager#NextLevel)
* **GameScreen_Out ➡️ GameScreen_In** (Level | House | Go to level entry point | Finish Level)
* **GameScreen_In ➡️GameScreen_Out** (Level | Grid | Props | Gate | Go to level entry point | Finish Level)
* **GameOver ➡️StartScreen** (see LevelSelector)

## Notes

* the **Loading screen** is loaded everytime we are moving from one scene to another (LevelManager | Scene Loading)
* the **Game over screen** is loaded when the player died (GameManager | Game over Screen)

