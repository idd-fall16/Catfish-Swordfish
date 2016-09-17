/* Graph I2C Accelerometer On RedBear Duo over Serial Port
 * Adafruit Part 2809 LIS3DH - http://adafru.it/2809
 * This example shows how to program I2C manually
 * I2C Pins SDA1==D0, SCL1 == D1
 * Default address: 0x18
 */
 
// do not use the cloud functions - assume programming through Arduino IDE
#if defined(ARDUINO) 
SYSTEM_MODE(MANUAL); 
#endif
// Basic demo for accelerometer readings from Adafruit LIS3DH

#include "Adafruit_LIS3DH.h"
#include "Adafruit_Sensor.h"

// I2C
Adafruit_LIS3DH lis = Adafruit_LIS3DH();

// const float alpha = 0.5;
double prevRoll = 0;
double prevPitch = 0;

double pi = 3.14159265;

// Photoresistor
int photoResistorPin = D10;

void setup() {
  
  Serial.begin(9600);
  Serial.println("LIS3DH test!");
  
  if (! lis.begin(0x18)) {   // change this to 0x19 for alternative i2c address
    Serial.println("Couldnt start");
    while (1);
  }
  Serial.println("LIS3DH found!");
  
  lis.setRange(LIS3DH_RANGE_2_G);   // 2, 4, 8 or 16 G!
}

void loop() {
  double pitch, roll;
  lis.read();

  sensors_event_t event; 
  lis.getEvent(&event);
  
  roll  = ((atan2(-lis.y, lis.z)*180.0)/pi + prevRoll) / 2;
  pitch = ((atan2(lis.x, sqrt(lis.y*lis.y + lis.z*lis.z))*180.0)/pi + prevPitch) / 2;
  prevRoll = roll;
  prevPitch = pitch;
  delay(100); 

  String res = "";
  if (roll > 0) {
    res = res + "1";
  } else {
    res = res + "0";
  }
  if (pitch > 0) {
    res = res + "1";
  } else {
    res = res + "0";
  }

  if (analogRead(photoResistorPin) > 9) {
    res = res + "1";
  } else {
    res = res + "0";
  }
  
  Serial.println(res);
}


