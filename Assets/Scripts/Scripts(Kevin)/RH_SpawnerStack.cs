using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    List<GameObject> SpawnerStack;
    int top = 0;

	// Use this for initialization
	void Awake ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private int Pop()
    {
        SpawnerStack.RemoveAt(top);
        return top--;
    }

    private void Push(GameObject g)
    {
        SpawnerStack.Add(g);
        top = SpawnerStack.IndexOf(g);
    }

    private GameObject Peek()
    {
        return SpawnerStack[top];
    }
}
