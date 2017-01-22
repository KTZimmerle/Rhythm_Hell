using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	public string sceneToLoad = "Main Menu";

	bool checkWin = false;
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

	void BeatListDone() {
		checkWin = true;
	}

	void Update () {
		if (checkWin) {
			GameObject[] wavesA = GameObject.FindGameObjectsWithTag ("waveA");
			GameObject[] wavesB = GameObject.FindGameObjectsWithTag ("waveB");
			GameObject[] wavesC = GameObject.FindGameObjectsWithTag ("waveC");

			if (wavesA.Length == 0 && wavesB.Length == 0 && wavesC.Length == 0) {
				checkWin = false;
				GameOverWin ();
			}
		}
	}
}
