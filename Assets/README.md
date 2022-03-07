# General

## Update

* Change the version in Project Settings > Player
* Change the version in the StartScreen

## Run the Game

* **Using Unity Remote**
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
* **Building the .apk**
  * File > Build Settings
  * Select a device
  * Build and Run
  * **Quite long** (unless using Mono)
* **Cloud build**
  * Disabled
  * **Quite long too**

## Assets

* [Door / House](https://kalponic-studio.itch.io/side-scroller-village-tileset)
* [Pipoya](https://pipoya.itch.io/pipoya-rpg-tileset-32x32)

## Notes
### Scene
#### Camera

- Move the "Regular camera" to change the view inside the editor
- You can set the zoom of the camera by changing the size (editor) and the values for camera zoom (in the camera controller)

### Tilemaps

- To create a smart tile, create a "Rule tile" and define how the tile should behave
- In the texture, make sure that you set the **Pixels per unit**
  - Set the texture to multiple if this is a set
  - You may change the filter mode (ex: Point)
  - You may change the max size (ex: 512)
  - You may change the compression (ex: none)
  - Apply
  - If this is a set, open the sprite editor and split the texture accordingly