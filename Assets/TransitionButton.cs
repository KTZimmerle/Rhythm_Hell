using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void EnableButton()
	{
		GetComponent<UnityEngine.UI.Image> ().enabled = true;
		GetComponent<UnityEngine.UI.Button> ().enabled = true;
		GetComponentInChildren<UnityEngine.UI.Text> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
