using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector3 move;
	public float speed = 5.0f;
	float timer;
	public float timeToRun = 0.5f;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {


		move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetButton ("Fire1")){
			timer += Time.deltaTime;
			print (timer);
			if (timer > timeToRun){
				speed = 8.0f;
			}

		}
		else{
			speed = 5.0f;
			timer = 0.0f;
		}

	}
}
