# Scenes

* **StartScreen**: The first screen of the game
  * Use **LoadScreen**
  * Use **GameScreen**
* **LoadScreen**: A screen shown when loading a new level
* **GameScreen**: the game itself

## Update

* Change the version in Project Settings > Player
* Change the version in the StartScreen

## Play

* **Test**
  * You can install [Unity Remote 5](https://play.google.com/store/apps/details?id=com.unity3d.mobileremote&hl=en_US&gl=US) on your mobile
  * Start the app
  * Ensure that usb debugging mode is enabled
  * Connect your device to your computer
  * Go to File > Build Settings
  * Check that your device is listed in "Run devices"
  * Close the window
  * Go to Project Settings > Editor and select "Any Device" for Device
  * Press "play" in the editor
  * You should see the game on your mobile (in low quality)
* **Development**
  * File > Build Settings
  * Select a device
  * Build and Run
  * **May be long**