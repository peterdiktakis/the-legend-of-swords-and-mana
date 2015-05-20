using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//Character variables

	public float timeToRun = 0.5f;
	public float rollSpeedModifier = 10.2f;
	public float speed = 5.0f;

	Vector3 move;
	Vector3 direction;
	
	float timer;
	bool isRolling;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		isRolling = false;
		direction = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

		print (direction);
		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (!isRolling) {
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
				timer += Time.deltaTime;
				if (timer > timeToRun) {
					speed = 8.0f;
				}
				
			} else {
				speed = 5.0f;
				timer = 0.0f;
			}

			if (Input.GetButtonDown ("Fire2")) {
				isRolling = true;
			}
		} else {
			//transform.position += direction;
		}





	}
}
