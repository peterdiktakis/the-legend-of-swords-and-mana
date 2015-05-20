﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//Character variables

	public float timeToRun = 0.5f;
	public float timeToRoll = 0.2f;
	public float rollSpeedModifier = 0.05f;
	public float speed = 5.0f;

	Vector3 move;
	Vector3 direction;
	Vector3 rollDirection;
	
	float runTimer;
	float rollTimer;
	bool isRolling;

	// Use this for initialization
	void Start () {
		runTimer = 0.0f;
		rollTimer = 0.0f;
		isRolling = false;
		direction = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

		print (isRolling + "      "  + rollTimer);
		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (!isRolling) {
			rollTimer = 0.0f;
			transform.position += move * speed * Time.deltaTime;

			if(Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0)
				direction = new Vector3(0.0f, 0.0f, 0.0f);

			if(Input.GetAxis ("Horizontal") > 0)
			{
				direction = new Vector3(1.0f, 0.0f, 0.0f);
			}
			else if(Input.GetAxis ("Horizontal") < 0){
				direction = new Vector3(-1.0f, 0.0f, 0.0f);
			}
			if(Input.GetAxis ("Vertical") > 0)
			{
				direction = new Vector3(0.0f, 1.0f, 0.0f);
			}
			else if(Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(0.0f, -1.0f, 0.0f);
			}

			if(Input.GetAxis ("Horizontal") > 0 && Input.GetAxis ("Vertical") > 0){
				direction = new Vector3(1.0f, 1.0f, 0.0f);
			}
			else if(Input.GetAxis ("Horizontal") > 0 && Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(1.0f, -1.0f, 0.0f);
			}
			else if(Input.GetAxis ("Horizontal") < 0 && Input.GetAxis ("Vertical") > 0){
				direction = new Vector3(-1.0f, 1.0f, 0.0f);
			}
			else if(Input.GetAxis ("Horizontal") < 0 && Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(-1.0f, -1.0f, 0.0f);
			}

			if (Input.GetButton ("Fire1")) {
				runTimer += Time.deltaTime;
				if (runTimer > timeToRun) {
					speed = 8.0f;
				}
				
			} else {
				speed = 5.0f;
				runTimer = 0.0f;
			}

			if (Input.GetButtonDown ("Fire2")) {
				isRolling = true;
				rollDirection = direction;
			}
		} else {
			rollTimer += Time.deltaTime;
			//For Diagonal Rolling
			if(rollDirection.x == 0 || rollDirection.y == 0)
				transform.position += rollDirection * 0.4f;
			else //For 4-axis Rolling
				transform.position += rollDirection * 0.25f;

			if(rollTimer > timeToRoll){
				isRolling = false;
			}
			transform.position += move * speed * Time.deltaTime;

		}





	}
}
