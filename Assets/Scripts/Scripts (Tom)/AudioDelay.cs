using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour {
    public float timer;
    public PauseMenu menu;
    private bool pause = false;
	// Use this for initialization
	void Start () {
        Invoke("PlayAudio", timer);
	}
	
    void Update ()
    {
        if (menu.isPaused)
        {
            GetComponent<AudioSource>().Pause();
            pause = true;
        }
        if (menu.resumeCalled)
        {
            GetComponent<AudioSource>().Play();
            menu.resumeCalled = false;
            pause = false;
        }
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
