using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 move;
	float speed;

	// Use this for initialization
	void Start () {
		speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {

		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetButton("Fire1"))
			speed = 0.05f;
		else {
			speed = 5.0f;
		}

	}
}
