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
    RH_RespawnPoint[] resPt = new RH_RespawnPoint[3];

	void Start () {
        resPt[0] = GameObject.FindGameObjectWithTag("SpawnPt1").GetComponent<RH_RespawnPoint>();
        resPt[1] = GameObject.FindGameObjectWithTag("SpawnPt2").GetComponent<RH_RespawnPoint>();
        resPt[2] = GameObject.FindGameObjectWithTag("SpawnPt3").GetComponent<RH_RespawnPoint>();
        overlayText = FindObjectOfType<OverlayController> ().GetComponent<UnityEngine.UI.Text>();
		transButton = FindObjectOfType<TransitionButton> ();
		destroyed = GetComponent<AudioSource> ();
		GameObject.FindGameObjectWithTag ("menumusic").GetComponent<AudioSource>().Play();
	}

	void NextScene() {
		//Debug.Log ("changing to next scene " + sceneToLoad);
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}

	void CreditsScene() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Credit");
	}

	void QuitGame()
	{
		Application.Quit();
	}

	void GameOverLose() {
		if (!gameOver) {
			gameOver = true;
			overlayText.text = "Game Over!";
			overlayText.enabled = true;
			transButton.SendMessage ("EnableButton");
		}
	}

	public void GameOverWin() {
		if (!gameOver) {
			destroyed.Play ();
			gameOver = true;
			overlayText.text = "Victory!";
			overlayText.enabled = true;
			transButton.SendMessage ("EnableButton");
            resPt[0].beginFadeout();
            resPt[1].beginFadeout();
            resPt[2].beginFadeout();
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
