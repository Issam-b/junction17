﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using HoloToolkit.Unity.InputModule; 

public class Rotater : MonoBehaviour, IInputClickHandler, IInputHandler  { 
	public float smooth = 2.0F; 
	public float tiltAngle = 30.0F; 
	float tiltAroundY; 
	void Update() { 
		//float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle; 
		tiltAroundY+= Time.deltaTime * smooth * tiltAngle; 
		Quaternion target = Quaternion.Euler(0, tiltAroundY, 0); 
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth); 
	} 
	public void OnInputClicked(InputClickedEventData eventData) 
	{ 
		// AirTap code goes here 
		//this.transform.Rotate(); 
	} 
	public void OnInputDown(InputEventData eventData) 
	{ } 
	public void OnInputUp(InputEventData eventData) 
	{ } 
} 