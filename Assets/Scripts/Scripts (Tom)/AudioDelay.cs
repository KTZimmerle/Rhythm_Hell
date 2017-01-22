using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
        Invoke("PlayAudio", timer);
	}
	
	void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
        CancelInvoke();
    }
}
