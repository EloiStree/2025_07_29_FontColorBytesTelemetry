
# Font Color Bytes Telemetry

Exploration of exporting game information through font color telemetry for Webcam and Quest 3.

### Premise of this project:

I created telemetry in *World of Warcraft* using an addon and Cheat Engine.
Then I realized that you could just print the text information you want to export as color.
It works, but only if you use a capture device or DLL screen reader, then create a network broadcaster.

However, you could export the info directly from the game to the target device using a webcam placed in front of the screen.

I'm exploring this because I’m working on the Quest 3.

Being able to export telemetry from a screen to the Quest 3 is an amazing topic.

You can do it by writing code in your game engine—here, Unity 3D—or by using a colored font in a moddable game.

So, I created a 256-character ASCII font. But apparently, fonts are limited to 127 characters in-game and have problems with some characters that are "executable."

So I created a base-60 font with bytes as characters to be exported. You could use only one color.
But if you mix colors, then you can export the same quantity of information over an extremely large range of possibilities.
See: [https://github.com/EloiStree/2025\_07\_23\_WowAddonTextToColorTelemetry](https://github.com/EloiStree/2025_07_23_WowAddonTextToColorTelemetry)

---

### Questions posed by this repository:

From this font and a dedicated Unity script, how can we export computed and game information to the Quest 3 by having it visually read the screen?

---

### Challenges:

* The information needs to be readable from 3–5 meters away.
* The screen emits light, which helps a lot—but also introduces challenges:

  * Yellow → becomes white
  * Cyan → becomes white
  * Blue → looks like cyan
  * Orange and brown are indistinguishable
  * Red → looks orange
  * White becomes 100% white or gray
  * Webcam grain appears
  * Two colors close together may merge in the webcam sensor
  * ...

---

I don’t have the answer to whether this is a good idea.

But my gut tells me that it’s at least an amazing technology to have in the toolbox.

If it works, the first sample is going to be:
**Play *World of Warcraft* with telemetry displayed in the Quest 3 from the screen**
(Bonus: as a blind player with bHapticSuite).

