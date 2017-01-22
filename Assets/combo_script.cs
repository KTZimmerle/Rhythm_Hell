using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combo_script : MonoBehaviour {

	GameObject player;
	ShieldController shieldA;
	ShieldController shieldB;
	ShieldController shieldC;
	private int a_count;
	private int b_count;
	private int c_count;

	public Text combo;
	private int total_count; 
	private bool miss = false; 
	// Use this for initialization
	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		shieldA = player.transform.GetChild(0).GetComponentInChildren<ShieldController>();
		shieldB = player.transform.GetChild(1).GetComponentInChildren<ShieldController>();
		shieldC = player.transform.GetChild(2).GetComponentInChildren<ShieldController>();
		Debug.Log("SA: " + shieldA);
		Debug.Log("SB: " + shieldB);
		Debug.Log("SC: " + shieldC);
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log("Shield count: " + shieldA);
		miss = player.transform.GetComponent<PlayerController>().miss;
		if (miss == false)
		{
			a_count = shieldA.combo_count;
			b_count = shieldB.combo_count;
			c_count = shieldC.combo_count;
			total_count = a_count + b_count + c_count;
			combo.text = total_count.ToString();
		}
		else 
		{
			shieldA.combo_count = 0;
			shieldB.combo_count = 0;
			shieldC.combo_count = 0;
			a_count = 0;
			b_count = 0;
			c_count = 0;
			total_count = 0;
			combo.text = total_count.ToString();	
		}
	}
}
