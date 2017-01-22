using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	public string sceneToLoad = "Main Menu";

	void Start () {
		
	}

	void NextScene() {
		Debug.Log ("changing to next scene " + sceneToLoad);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}

	void Update () {
		
	}
}
