using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	//****************Stamina****************//
		//Variables
		public float startingStamina;
		public float currentStamina;

		//Slider 
		public Slider staminaSlider;

		//Timer
		float staminaTimer;

		//Checks
		public bool changed = false;
		public bool hasChanged = false;

		//Movement
		Movement running;

		// Timer/Stamina Modifiers
		const float STAMINA_MODIFIER = 60f;
		const float TIMER_CHECK = 1.0f;

	//****************Health****************//

	void Awake()
	{
		currentStamina = startingStamina;
	}

	// Use this for initialization
	void Start () {
		staminaTimer = 0.0f;
		running = GetComponent<Movement> ();
	}


	// Update is called once per frame
	void Update () {


		staminaSlider.value = currentStamina;
		if (currentStamina > startingStamina)
			currentStamina = startingStamina;
		if (currentStamina <= 0)
			currentStamina = 0;

		if (changed == true) {
			staminaTimer = 0.0f;
			changed = false;
		}

		//Rolling
		if (currentStamina != startingStamina && changed == false && running.isRunning != true) {
			staminaTimer += Time.deltaTime;

			if (staminaTimer > TIMER_CHECK)
				currentStamina += STAMINA_MODIFIER * Time.deltaTime;


		} else if (currentStamina <= 0)
			staminaTimer = 0.0f;



		if (currentStamina == startingStamina)
			changed = false;
	}
}
