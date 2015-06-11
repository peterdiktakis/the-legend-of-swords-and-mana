using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//Character variables

	public float timeToRun = 0.5f;
	public float timeToRoll = 0.2f;
	public float rollSpeedModifier = 0.05f;
	public float speed = 5.0f;
	public int rollStamina = 5;

	Vector3 move;
	Vector3 direction;
	Vector3 rollDirection;
	
	float runTimer;
	float rollTimer;
	bool isRolling;
	public bool isRunning;

	PlayerGUI stamina;

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

		print (runTimer);
		//print (isRolling + "      "  + rollTimer);
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


			
			if (Input.GetButtonUp ("Fire2") && stamina.currentStamina > rollStamina && move.magnitude > 0 && !isRunning) {
				stamina.currentStamina -= rollStamina;
				stamina.changed = true;
				isRolling = true;
				rollDirection = direction;
			}

			if (Input.GetButton ("Fire2") && move.magnitude > 0) {
				runTimer += Time.deltaTime;
				if (runTimer > timeToRun) {
					isRunning = true;
					speed = 8.0f;
					stamina.currentStamina -= Time.deltaTime * 25;
				}
				
			} 
			else {
				speed = 5.0f;
				runTimer = 0.0f;
				isRunning = false;
			}

		
			if(stamina.currentStamina <= 0)
			{
				speed = 5.0f;
				runTimer = 0.0f;
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
