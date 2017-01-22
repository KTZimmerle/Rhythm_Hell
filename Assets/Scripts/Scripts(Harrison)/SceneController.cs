using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	public string sceneToLoad = "Main Menu";

	bool checkWin = false;
	bool gameOver = false;
	UnityEngine.UI.Text overlayText;
	TransitionButton transButton;
	AudioSource destroyed;

	void Start () {
		overlayText = FindObjectOfType<OverlayController> ().GetComponent<UnityEngine.UI.Text>();
		transButton = FindObjectOfType<TransitionButton> ();
		destroyed = GetComponent<AudioSource> ();
	}

	void NextScene() {
		//Debug.Log ("changing to next scene " + sceneToLoad);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}

	void GameOverLose() {
		if (!gameOver) {
			gameOver = true;
			overlayText.text = "Game Over!";
			overlayText.enabled = true;
			transButton.SendMessage ("EnableButton");
		}
	}

	void GameOverWin() {
		if (!gameOver) {
			destroyed.Play ();
			gameOver = true;
			overlayText.text = "Victory!";
			overlayText.enabled = true;
			transButton.SendMessage ("EnableButton");
		}
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
