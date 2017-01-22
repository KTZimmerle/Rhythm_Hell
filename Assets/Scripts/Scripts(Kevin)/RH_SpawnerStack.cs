using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_SpawnerStack : MonoBehaviour {

	List<RH_RespawnPoint> SpawnerStack = new List<RH_RespawnPoint>();
    RH_RespawnPoint respawnPtOne;
    RH_RespawnPoint respawnPtTwo;
    RH_RespawnPoint respawnPtThree;
    RH_BeatList beatListOne;
    RH_BeatList beatListTwo;
    RH_BeatList beatListThree;
    RH_BeatList currentBL;
    bool gameStarted = false;
    private int top = 0;
    double timer;

	// Use this for initialization
	void Awake ()
    {
        respawnPtOne = GameObject.FindGameObjectWithTag("SpawnPt1").GetComponent<RH_RespawnPoint>();
        respawnPtTwo = GameObject.FindGameObjectWithTag("SpawnPt2").GetComponent<RH_RespawnPoint>();
        respawnPtThree = GameObject.FindGameObjectWithTag("SpawnPt3").GetComponent<RH_RespawnPoint>();
        beatListOne = GameObject.FindGameObjectWithTag("BL1").GetComponent<RH_BeatList>();
        //respawnPtOne.SpawnEnemy();

    }

	void Start()
	{
		/*AddSpawn(respawnPtOne);
		AddSpawn(respawnPtOne);
		AddSpawn(respawnPtTwo);
		AddSpawn(respawnPtThree);*/
		InitializeNextSong(beatListOne);
	}

    RH_RespawnPoint HandleRespawnPt(string spawnName)
    {
        RH_RespawnPoint r = null;
        if (spawnName.CompareTo("SpawnPt1") == 0)
            r = respawnPtOne;
        if (spawnName.CompareTo("SpawnPt2") == 0)
            r = respawnPtTwo;
        if (spawnName.CompareTo("SpawnPt3") == 0)
            r = respawnPtThree;

        return r;
    }

    //when choosing a song, it will take a list of preset positions to add to the stack
    void InitializeNextSong(RH_BeatList bl)
    {
        for (int i = 0; i < bl.getSTLength(); i++)
        {
            AddSpawn(HandleRespawnPt(bl.spawnLocation[i]));
        }
        currentBL = bl;
        gameStarted = true;
		timer = currentBL.nextTime();
    }

	// Update is called once per frame
	void Update ()
    {
        if(timer < 0.0f && gameStarted && currentBL != null)
        {
            //check to make sure that the list still has more times to go through before spawning or getting next time
            if (!currentBL.isDone)
            {
                ActivateSpawn();
                timer = currentBL.nextTime();
            }
            else
                currentBL = null;
        }
        if (gameStarted && currentBL != null)
            timer -= Time.deltaTime;
	}

    public void AddSpawn(RH_RespawnPoint spawn)
    {
        Push(spawn);
    }

    public void ActivateSpawn()
    {
		if(SpawnerStack.Count > 0){
			Pop();
		}
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
        //top = SpawnerStack.IndexOf(r);
		top = SpawnerStack.Count - 1;

	}

    private RH_RespawnPoint Peek()
    {
        return SpawnerStack[top];
    }
}
