using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	public string sceneToLoad = "Main Menu";

	UnityEngine.UI.Text overlayText;
	TransitionButton transButton;

	void Start () {
		//UnityEngine.UI.Text[] texts = FindObjectsOfType<UnityEngine.UI.Text> ();

		overlayText = FindObjectOfType<OverlayController> ().GetComponent<UnityEngine.UI.Text>();
		transButton = FindObjectOfType<TransitionButton> ();
	}

	void NextScene() {
		Debug.Log ("changing to next scene " + sceneToLoad);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}

	void GameOverLose() {

		overlayText.text = "Game Over!";
		overlayText.enabled = true;
		transButton.SendMessage ("EnableButton");
	}

	void GameOverWin() {
		overlayText.text = "Victory!";
		overlayText.enabled = true;
		transButton.SendMessage ("EnableButton");
	}

	void Update () {
		
	}
}
