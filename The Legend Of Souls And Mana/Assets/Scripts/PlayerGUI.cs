using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public float startingStamina;
	public float currentStamina;
	public Slider staminaSlider;
	float staminaTimer;

	Texture2D progressBarEmpty;
	Texture2D progressBarFull;

	public bool changed = false;
	public bool hasChanged = false;

	void Awake()
	{
		currentStamina = startingStamina;
	}

	// Use this for initialization
	void Start () {
		staminaTimer = 0.0f;
	}


	// Update is called once per frame
	void Update () {
		print (staminaTimer);
		staminaSlider.value = currentStamina;
		if (currentStamina > startingStamina)
			currentStamina = startingStamina;
		if (currentStamina < 0)
			currentStamina = 0;

		if (changed == true) {
			staminaTimer = 0.0f;
			changed = false;
		}
		if (currentStamina != startingStamina && changed == false) {
			staminaTimer += Time.deltaTime;

			if(staminaTimer > 1.0f)
				currentStamina += 60f*Time.deltaTime;


		}
		if (currentStamina == startingStamina)
			changed = false;
	}
}
