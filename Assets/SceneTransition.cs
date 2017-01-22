using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ReturnToMenu ();
		}
	}

	public void ReturnToMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Main Menu");
	}
}
