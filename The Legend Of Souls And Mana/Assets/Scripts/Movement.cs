using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 move;
	public float speed = 5.0f;
	float timer;
	public float timeToRun = 0.5f;
	public float rollSpeedModifier = 10.2f;
	Vector3 direction;
	bool isRolling;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		isRolling = false;

	}
	
	// Update is called once per frame
	void Update () {

		print (transform.position);
		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (!isRolling) {
			transform.position += move * speed * Time.deltaTime;


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
				direction = move;
			}
		} else {
			transform.position += direction;
		}





	}
}
