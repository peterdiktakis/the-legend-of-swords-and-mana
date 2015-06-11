using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//Timers
	float runTimer;
	float rollTimer;
	public float timeToRun = 0.5f;
	public float timeToRoll = 0.2f;
	
	//Speed
	public float rollSpeedModifier = 0.05f;
	public float speed = 5.0f;
	const int BASE_SPEED = 5;
	const int RUN_SPEED = 8;

	//Movement
	Vector3 move;
	Vector3 direction;
	Vector3 rollDirection;

	//Checks
	bool isRolling;
	public bool isRunning;

	//Stamina
	PlayerGUI stamina;
	public int rollStamina = 5;
	const int STAMINA_MODIFIER = 25;

	//Roll/Run Modifiers
	const float DIAGONAL_OFFSET = 0.4f;
	const float AXIS_OFFSET = 0.25f;


	// Use this for initialization
	void Start () {
		runTimer = 0.0f;
		rollTimer = 0.0f;
		isRolling = false;
		isRunning = false;
		direction = new Vector3 (0.0f, 0.0f, 0.0f);
		stamina = GetComponent<PlayerGUI> ();
		this.GetComponent<Renderer> ().material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {

		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (!isRolling) {
			rollTimer = 0.0f;
			transform.position += move * speed * Time.deltaTime;

			//Default Facing
			if(Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0)
				direction = new Vector3(0.0f, 0.0f, 0.0f);

			//Front Face Right
			if(Input.GetAxis ("Horizontal") > 0)
			{
				direction = new Vector3(1.0f, 0.0f, 0.0f);
			}	//Front Face Left
			else if(Input.GetAxis ("Horizontal") < 0){
				direction = new Vector3(-1.0f, 0.0f, 0.0f);
			}
			//Front Face Up
			if(Input.GetAxis ("Vertical") > 0)
			{
				direction = new Vector3(0.0f, 1.0f, 0.0f);
			}  //Front Face Down
			else if(Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(0.0f, -1.0f, 0.0f);
			}

			//Front Face Up-Right
			if(Input.GetAxis ("Horizontal") > 0 && Input.GetAxis ("Vertical") > 0){
				direction = new Vector3(1.0f, 1.0f, 0.0f);
			}  //Front Face Down-Right
			else if(Input.GetAxis ("Horizontal") > 0 && Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(1.0f, -1.0f, 0.0f);
			} //Front Face Up-Left
			else if(Input.GetAxis ("Horizontal") < 0 && Input.GetAxis ("Vertical") > 0){
				direction = new Vector3(-1.0f, 1.0f, 0.0f);
			} //Front Face Down-Left
			else if(Input.GetAxis ("Horizontal") < 0 && Input.GetAxis ("Vertical") < 0){
				direction = new Vector3(-1.0f, -1.0f, 0.0f);
			}


			//Rolling 
			if (Input.GetButtonUp ("Fire2") && stamina.currentStamina > rollStamina && move.magnitude > 0 && !isRunning) {
				stamina.currentStamina -= rollStamina;
				stamina.changed = true;
				isRolling = true;
				rollDirection = direction;
			}

			//Running
			if (Input.GetButton ("Fire2") && move.magnitude > 0) {
				runTimer += Time.deltaTime;
				if (runTimer > timeToRun) {
					isRunning = true;
					speed = RUN_SPEED;
					stamina.currentStamina -= Time.deltaTime * STAMINA_MODIFIER;
				}
				
			} 
			else { //Reset values when running ends
				speed = BASE_SPEED;
				runTimer = 0.0f;
				isRunning = false;
			}


			//Stops the ability to run once Stamina reaches 0
			if(stamina.currentStamina <= 0)
			{
				speed = BASE_SPEED;
				runTimer = 0.0f;
			}



		} else {  //Rolling
			rollTimer += Time.deltaTime;

			//For Diagonal Rolling
			if(rollDirection.x == 0 || rollDirection.y == 0)
				transform.position += rollDirection * DIAGONAL_OFFSET;
			else //For 4-axis Rolling
				transform.position += rollDirection * AXIS_OFFSET;

			//Stops rolling after a timeframe
			if(rollTimer > timeToRoll){
				isRolling = false;
			}
			transform.position += move * speed * Time.deltaTime;

		}





	}
}
