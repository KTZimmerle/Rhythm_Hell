﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_Respawner : MonoBehaviour {

    /*public Vector2 RespawnPt1;
    public Vector2 RespawnPt2;
    public Vector2 RespawnPt3;*/

    public GameObject Enemy;
    List<GameObject> SpawnerStack;
    //public GameObject EnemyWaveAttack;

    void Awake()
    {
        //TODO: once more game systems are in place, set up variables here to be private
        //      and initialize in this script
    }

    // Update is called once per frame
    void Update()
    {

    }


    private GameObject Pop(GameObject g)
    {
        SpawnerStack.Remove(g);
        return g;
    }

    private void Push(GameObject g)
    {

    }

    /*private GameObject Peek(GameObject g)
    {
        return SpawnerStack.LastIndexOf(g);
    }*/

    public void SpawnEnemy(Vector3 pt)
    {
        GameObject clone = Instantiate(Enemy, pt, Enemy.transform.rotation) as GameObject;
    }
}
