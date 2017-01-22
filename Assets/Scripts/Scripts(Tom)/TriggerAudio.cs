using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour {
    public float timer = 0;
    // Use this for initialization
    void Start() {
        Invoke("PlayAudio", timer);
    }

    void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
        CancelInvoke();
    }
}
	
