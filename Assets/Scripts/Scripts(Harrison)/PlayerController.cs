using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int hitPoints = 10;
	public int damagePerHit = 1;
	EnergyBarController eBar;
	public bool miss; 
	GameObject player;
	ShieldController shieldA;
	ShieldController shieldB;
	ShieldController shieldC;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		shieldA = player.transform.GetChild(1).GetComponentInChildren<ShieldController>();
		shieldB = player.transform.GetChild(2).GetComponentInChildren<ShieldController>();
		shieldC = player.transform.GetChild(3).GetComponentInChildren<ShieldController>();

	}

	void Start () {
		eBar = FindObjectOfType<EnergyBarController> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("player hit");
		Destroy (other.gameObject);
		eBar.DecrementEnergy ();
		hitPoints -= damagePerHit;
		//also reduce the energy bar if hit
		miss = true; 
		if (hitPoints <= 0) {
			FindObjectOfType<SceneController> ().SendMessage ("GameOverLose");
		}
	}

	void Update () {
		if (shieldA.miss == false && shieldB.miss == false && shieldB.miss == false)
		{
			miss = false;
		}
		else
		{
			shieldA.combo_count = 0;
			shieldB.combo_count = 0;
			shieldC.combo_count = 0;
			miss = true;
		}
	}
}
