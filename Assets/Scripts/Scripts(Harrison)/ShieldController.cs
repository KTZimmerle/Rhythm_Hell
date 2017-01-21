using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
	public KeyCode activateOn = KeyCode.None;

	SpriteRenderer render;
	Color activeColor;
	Color passiveColor;
	bool isActive = false;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		activeColor = render.color;
		passiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0);
	}

	void OnTriggerStay2D(Collider2D other) {
		if (isActive) {
			other.SendMessage ("OnBlock", SendMessageOptions.DontRequireReceiver);
			Debug.Log ("blocked");
			Destroy (other.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		isActive = Input.GetKey (activateOn);

		if (isActive) {
			render.color = activeColor;
		} else {
			render.color = passiveColor;
		}
	}
}
