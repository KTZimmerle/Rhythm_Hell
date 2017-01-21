using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
	public KeyCode activateOn = KeyCode.None;
	public int activeTimeMillis = 200;

	SpriteRenderer render;
	Color activeColor;
	Color passiveColor;
	bool isActive = false;
	float timeElapsed = 0.0f;
	EnergyBarController eBar;

	// Use this for initialization
	void Start () {
		eBar = FindObjectOfType<EnergyBarController> ();
		render = GetComponent<SpriteRenderer> ();
		activeColor = render.color;
		passiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0);
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isActive) {
			other.SendMessage ("OnBlock", SendMessageOptions.DontRequireReceiver);
			Debug.Log ("blocked");
			Destroy (other.gameObject);
			eBar.IncrementEnergy ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if (Input.GetKeyDown (activateOn)) {
			isActive = true;
			timeElapsed = 0.0f;
		}
		else if (timeElapsed > activeTimeMillis / 1000.0f) {
			isActive = false;
		}

		//isActive = Input.GetKeyDown (activateOn);

		if (isActive) {
			render.color = activeColor;
		} else {
			render.color = passiveColor;
		}
	}
}
