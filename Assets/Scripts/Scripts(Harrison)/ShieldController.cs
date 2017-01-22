﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
	public KeyCode activateOn = KeyCode.None;
	public int activeTimeMillis = 200;

	enum Version{waveA,waveB,waveC};
	Version myVersion;

	SpriteRenderer render;
	Color activeColor;
	Color passiveColor;
	bool isActive = false;
	float timeElapsed = 0.0f;
	EnergyBarController eBar;

    RH_ScoreSystem ss;

	// Use this for initialization
	void Start () {
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
		eBar = FindObjectOfType<EnergyBarController> ();
		render = GetComponent<SpriteRenderer> ();
		activeColor = render.color;
		passiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0);

	}

	void OnTriggerStay2D(Collider2D other) {
		if (isActive) {
			other.SendMessage ("OnBlock", SendMessageOptions.DontRequireReceiver);
			Debug.Log ("blocked");
			if (other.tag == "waveA" && GetComponent<Transform>().tag == "ShieldA")//&& myVersion == Version.waveA)
			{
				Debug.Log("Cancel wave A");
				Destroy (other.gameObject);
			}
			if (other.tag == "waveB" && GetComponent<Transform>().tag == "ShieldW")//myVersion == Version.waveB)
			{
				Debug.Log("Cancel wave B");
				Destroy(other.gameObject);
			}
			if (other.tag == "waveC" && GetComponent<Transform>().tag == "ShieldD")//myVersion == Version.waveC)
			{
				Debug.Log("Cancel wave C");
				Destroy(other.gameObject);
			}

			eBar.IncrementEnergy ();
            ss.ModifyScore(100);
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
