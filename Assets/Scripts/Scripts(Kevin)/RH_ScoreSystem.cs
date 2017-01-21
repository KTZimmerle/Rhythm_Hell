using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RH_ScoreSystem : MonoBehaviour {

    public Text scoreText;
    public int score;

	// Use this for initialization
	void Awake () {
        score = 0;
        scoreText.text = "Score: " + score;
	}

    void ModifyScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: " + score;
    }
}
