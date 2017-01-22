using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	EnergyBarController eBar;

	void Start () {
		eBar = FindObjectOfType<EnergyBarController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("player hit");
		Destroy (other.gameObject);
		eBar.DecrementEnergy ();
	}

	void Update () {
	}
}
