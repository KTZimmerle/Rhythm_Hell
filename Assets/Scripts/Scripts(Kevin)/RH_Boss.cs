using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_Boss : MonoBehaviour {

    public int health = 20;
    RH_ScoreSystem ss;

	// Use this for initialization
	void Awake () {
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
	}

    // Unknown if boss does anything yet
    /*void Update () {
		
	}*/

    public void takeDamage(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            //boss dies, gain score
            ss.ModifyScore(1000);
            Destroy(gameObject);
        }
    }
}
