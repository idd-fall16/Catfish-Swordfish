## Catfish & Swordfish
HW3 - Game Controller - Catfish vs. Piranha
Jonathan Shum, Caroline Chen, Kingston Xu

![alt tag](https://raw.githubusercontent.com/idd-fall16/Catfish-Swordfish/master/Media/Swordfish.jpg)

![alt tag](https://raw.githubusercontent.com/idd-fall16/Catfish-Swordfish/master/Media/GameScreenShot.png)

Demo Link: https://youtu.be/4cFp8qCs_bQ 

In this game, the player moves a character side to side to dodge and shoot falling piranha. Using the custom controller, the player can control the movement of the character and attack the aggressive evil piranhas. Tilting the controller will move the player and pressing a button will trigger the character’s attack.

## Hardware

The game controller is laser cut from plywood and acrylic in the shape of a swordfish. We used a RedBear Duo microcontroller to read a 3 axis accelerometer and a force sensitive resistor. The microcontroller sends the sensor readings to the game via serial. Two leds on the eyes of the swordfish light up when the force sensitive resistor is pressed.

![alt tag](https://raw.githubusercontent.com/idd-fall16/Catfish-Swordfish/master/Media/Fritzing.png)

## Software

The data from the 3 axis accelerometer is converted into euler angles pitch and roll to estimate the orientation of the game controller.

The game “Pranhan” was made by Unity Technologies Japan. Using their source code, we modified the player control script to read from a serial port. Positive pitch moves the character to the right while negative pitch moves the character to the left. Upon pressing the force-sensitive resistor, if the analog signal is above the set threshold value, the output LED pin is digitally written to high to flash the eyes. 

## Reflection

This controller makes a simple game more fun. The controller worked very well but one issue we ran into was the reliability of the accelerometer. We initially wanted to use the absolute yaw angle to control the character but the accelerometer provided would quickly drift and not work well. We realized we would need additional sensors to get better values. A magnetometer or gyroscope would help refine the values for yaw.


## Credits

The "Pranhan" - Retro-Style 2D Shoting Game was made by Unity Technologies Japan. Their project is open source and is available in the repository [here](https://github.com/unity3d-jp/piranhan).