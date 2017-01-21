using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_SpawnerStack : MonoBehaviour {

    List<RH_RespawnPoint> SpawnerStack;
    RH_RespawnPoint respawnPtOne;
    RH_RespawnPoint respawnPtTwo;
    RH_RespawnPoint respawnPtThree;
    private int top = 0;

	// Use this for initialization
	void Awake ()
    {
        respawnPtOne = GameObject.FindGameObjectWithTag("SpawnPt1").GetComponent<RH_RespawnPoint>();
        respawnPtTwo = GameObject.FindGameObjectWithTag("SpawnPt2").GetComponent<RH_RespawnPoint>();
        respawnPtThree = GameObject.FindGameObjectWithTag("SpawnPt3").GetComponent<RH_RespawnPoint>();
        //respawnPtOne.SpawnEnemy();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AddSpawn(RH_RespawnPoint spawn)
    {
        Push(spawn);
    }

    public void ActivateSpawn()
    {
        if(SpawnerStack.Count > 0)
            Pop();
    }

    private int Pop()
    {
        //GameObject clone = Instantiate(Peek(), Peek().transform.position, Peek().transform.rotation);
        Peek().SpawnEnemy();
        SpawnerStack.RemoveAt(top);
        return top--;
    }

    private void Push(RH_RespawnPoint r)
    {
        SpawnerStack.Add(r);
        top = SpawnerStack.IndexOf(r);
    }

    private RH_RespawnPoint Peek()
    {
        return SpawnerStack[top];
    }
}
