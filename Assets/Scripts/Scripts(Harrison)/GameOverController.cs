using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnGameOver(){
		GetComponent<UnityEngine.UI.Text> ().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
