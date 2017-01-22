using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_RespawnPoint : MonoBehaviour {
    
    public float PosX;
    public float PosY;

    public GameObject Enemy;
    public GameObject Wave;
    public int health = 20;
    RH_ScoreSystem ss;
    //List<GameObject> SpawnerStack;
    //public GameObject EnemyWaveAttack;

    void Awake()
    {
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
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

    public void takeDamage(int dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            //boss dies, gain score
            ss.ModifyScore(1000);
            Destroy(gameObject);
        }
    }

    /*public void RandomizePosition(float xMinRange = -5.0f, float xMaxRange = 5.0f, float yMinRange = -5.0f, float yMaxRange = 5.0f)
    {
        PosX = Random.Range(xMinRange, xMaxRange);
        PosY = Random.Range(xMinRange, xMaxRange);
    }*/
}
