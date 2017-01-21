using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int meterMax = 100;
	public int chargeAmount = 10;

	public int meterValue = 0;

	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.SendMessage ("OnHit", SendMessageOptions.DontRequireReceiver);
		Debug.Log ("player hit");
		Destroy (other.gameObject);
	}




	public void OnBlock()
	{
		
	}

	void Update () {
		//meterValue = (meterValue + 1) % 101;
	}
}
