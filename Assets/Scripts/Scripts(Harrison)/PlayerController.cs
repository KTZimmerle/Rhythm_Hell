using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int hitPoints = 10;
	public int damagePerHit = 1;
	EnergyBarController eBar;

	void Start () {
		eBar = FindObjectOfType<EnergyBarController> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("player hit");
		Destroy (other.gameObject);
		eBar.DecrementEnergy ();
		hitPoints -= damagePerHit;
		//also reduce the energy bar if hit


		if (hitPoints <= 0) {
			FindObjectOfType<SceneController> ().SendMessage ("GameOver");
		}
	}

	void Update () {
	}
}
