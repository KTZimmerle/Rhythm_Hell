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

	void GameOver() {
		UnityEngine.UI.Text[] texts = FindObjectsOfType<UnityEngine.UI.Text> ();
		foreach(UnityEngine.UI.Text textElement in texts)
		{
			if (textElement.name == "Overlay Text") {
				textElement.text = "Game Over!";
				textElement.enabled = true;
			}
		}
	}

	void Update () {
		
	}
}
