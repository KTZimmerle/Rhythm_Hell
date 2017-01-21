using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_RespawnPoint : MonoBehaviour {

    /*public Vector2 RespawnPt1;
    public Vector2 RespawnPt2;
    public Vector2 RespawnPt3;*/
    public float PosX;
    public float PosY;
    /*public float minPosX = -5.0f;
    public float minPosY = -5.0f;
    public float maxPosX = 5.0f;
    public float maxPosY = 5.0f;*/
    public GameObject Enemy;
    public GameObject Wave;
    //List<GameObject> SpawnerStack;
    //public GameObject EnemyWaveAttack;

    void Awake()
    {
        //TODO: once more game systems are in place, set up variables here to be private
        //      and initialize in this script
        //RandomizePosition();
        
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/


    /*private GameObject Pop(GameObject g)
    {
        SpawnerStack.Remove(g);
        return g;
    }

    private void Push(GameObject g)
    {

    }*/

    /*private GameObject Peek(GameObject g)
    {
        return SpawnerStack.LastIndexOf(g);
    }*/

    public void SpawnEnemy()
    {
        GameObject clone = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
    }

    /*public void RandomizePosition(float xMinRange = -5.0f, float xMaxRange = 5.0f, float yMinRange = -5.0f, float yMaxRange = 5.0f)
    {
        PosX = Random.Range(xMinRange, xMaxRange);
        PosY = Random.Range(xMinRange, xMaxRange);
    }*/
}
