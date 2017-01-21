using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.SendMessage ("OnHit", SendMessageOptions.DontRequireReceiver);
		Debug.Log ("player hit");
		Destroy (other.gameObject);
	}

	void Update () {
		
	}
}
