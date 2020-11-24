"Just an ominous TV in the distance . . ."

-- INSTRUCTIONS --

Move around using WASD or the Arrows.

-- OBJECTIVE STATUS --

Overview:
I had too much fun with this project. I imported a custom VHS shader that
I made for a previous class, I hope that's ok! It felt worthy of a horror
theme, so I made lil offering to the Blood God. All objectives are
complete, as well as some extra credit I hope.

Lights/Player Movement/Third Person Camera:
Two lights are present, one is a directional for the dark sky and one is
a spotlight for the TV. Player movement and camera are simple. Player
loses control after getting too close to TV.

Global Post-Processing:
Film grain and bloom.

Local Post-Processing:
Chromatic aberration, lens distortion, color adjustments. This one is
named "Blood Zone" and is a child of the "Ominous TV" object. It kicks
in when the player gets too close to the TV (along with some other shit)

Shader Graph:
My favorite! Basically, I messed around with the shader graph for my Game
Graphics class last spring. I have no idea why it works, but it works!
I slapped this onto the TV screen. Also, to achieve the final death look,
I slapped this onto an invisible plane pressed up directly to the camera.
After a few seconds when the player enters the Blood Zone, I make the
plane visible  to simulate the VHS shader overtaking the screen. The lens
distortion worked nicely with this too.

Local Particle:
The "Blood Fire" that envelopes the player once they enter the Blood Zone.
Followed the Professor's lecture on this one, then tweaked the colors.

Global Particle:
Rain. Also followed the Professor on this one.

Animation:
Player bops up and down slowly when idle, tilts side to side when walking.
Again, per the Professor. Also made the player tweak out when dying, but
that aint technically an animation.

Extra Credit:
Sound effects! I added creepy ambience music that always plays, a sound
that plays when entering the Blood Zone (FNAF2 wink wink), and a static
noise sound when the player is "dead" and the static overtakes them. I
made two scripts to handle the sounds, per Brackeys on YouTube. Lastly,
I hope that my Blood Zone mechanic earns some points. Upon entering, the
second sound plays, the blood fire ignites, and the player loses control
and begins tweaking. Using a coroutine, a few seconds go by and then the
player "dies". The hidden VHS plane pressed up to the camera goes visible
and the final sound effect plays. Together, I hope all of these get me
some points. I promise I only sacrificed a couple people to the Blood God.
