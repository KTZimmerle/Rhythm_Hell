using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int hitPoints = 10;
	public int damagePerHit = 1;

	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("player hit");
		Destroy (other.gameObject);
		hitPoints -= damagePerHit;

		if (hitPoints <= 0) {
			FindObjectOfType<SceneController> ().SendMessage ("GameOver");
		}
	}

	void Update () {
	}
}
