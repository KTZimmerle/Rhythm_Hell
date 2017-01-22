using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RH_RespawnPoint : MonoBehaviour {
    
    public float PosX;
    public float PosY;

    public GameObject Enemy;
    public GameObject Wave;
    public int health = 5;
    RH_ScoreSystem ss;
    bool isDead = false;
    //List<GameObject> SpawnerStack;
    //public GameObject EnemyWaveAttack;

    void Awake()
    {
        isDead = false;
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
        GameObject clone;
        if (!isDead)
            clone = Instantiate(Enemy, transform.position, transform.rotation) as GameObject;
    }

    public void takeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            //boss dies, gain score
            ss.ModifyScore(1000);
            //Destroy(gameObject);
            isDead = true;
        }
    }

    public void beginFadeout()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color temp = sr.color;
        float alpha = temp.a;
        for (int i = 0; i < 120; i++)
        {
            temp.a = (119 - i) / 119;
            yield return new WaitForSeconds(0.017f);
        }
        yield return new WaitForSeconds(2.0f);
    }

    /*public void RandomizePosition(float xMinRange = -5.0f, float xMaxRange = 5.0f, float yMinRange = -5.0f, float yMaxRange = 5.0f)
    {
        PosX = Random.Range(xMinRange, xMaxRange);
        PosY = Random.Range(xMinRange, xMaxRange);
    }*/
}
