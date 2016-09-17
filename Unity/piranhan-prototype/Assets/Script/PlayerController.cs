using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour
{
	SerialPort stream = new SerialPort("COM3", 9600);
	private CatController controller;
	private ShotController shot;
	public bool serial = false;
	
	void Start ()
	{
		if (serial) {
	        stream.Open();
    	    stream.ReadTimeout = 50;
		}
		controller = GetComponent<CatController> ();
		shot = GetComponent<ShotController> ();
	}
	
	void Update ()
	{
		string value = "XXX";
		if (serial) {
			value = stream.ReadLine();
		}

		if (value[2] == '1') {
			shot.Shoot();
		} else if (Input.GetButtonDown ("Fire1")) {
			shot.Shoot ();
		}


		if (Input.GetAxis ("Vertical") > 0)
			controller.LookUp ();
		else if (Input.GetAxis ("Horizontal") != 0f)
			controller.Move (Input.GetAxis ("Horizontal"));
		else if (value[0] == '0') {
			// float rotation = (float)Double.Parse(value);
			// rotation = rotation/45.0f;
			controller.Move(1);
		} else if (value[0] == '1') {
			controller.Move(-1);
		}


		if (Input.GetKeyDown (KeyCode.LeftShift))
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	float Clamp(float value, float min, float max) {
    return (value < min) ? min : (value > max) ? max : value;
}
}
