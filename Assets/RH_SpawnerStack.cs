using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    List<GameObject> SpawnerStack;

	// Use this for initialization
	void Awake ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private GameObject Pop(GameObject g)
    {
        return g;
    }

    private void Push(GameObject g)
    {

    }

    private GameObject Peek(GameObject g)
    {
        return g;
    }
}
