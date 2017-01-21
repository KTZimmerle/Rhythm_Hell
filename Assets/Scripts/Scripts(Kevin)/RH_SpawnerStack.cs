using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    List<GameObject> SpawnerStack;
    private int top = 0;

	// Use this for initialization
	void Awake ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AddSpawn(GameObject obj)
    {
        Push(obj);
    }

    public void ActivateSpawn()
    {
        if(SpawnerStack.Count > 0)
            Pop();
    }

    private int Pop()
    {
        GameObject clone = Instantiate(Peek(), Peek().transform.position, Peek().transform.rotation);
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
