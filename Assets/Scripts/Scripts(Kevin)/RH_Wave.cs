using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_Wave : MonoBehaviour {

    public float startRadius;
    public float endRadius;
    public int scoreValue;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HitHandler(GameObject obj)
    {
        //if object is a wave, do something
        //if object is an enemy/player, do something
    }

    public int GetScoreValue()
    {
        return scoreValue;
    }
}
