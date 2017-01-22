using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour {
    public float timer;
    private bool pause = false;
	// Use this for initialization
	void Start () {
        Invoke("PlayAudio", timer);
	}
	
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                pause = true;
                GetComponent<AudioSource>().Pause();
            }
            else
            {
                pause = false;
                GetComponent<AudioSource>().Play();
            }
        }
    }
	void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
        CancelInvoke();
    }
}
