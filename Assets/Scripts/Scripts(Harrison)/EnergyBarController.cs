using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarController : MonoBehaviour
{
    public float maxEnergy = 100.0f;
    public float minEnergy = 0.0f;
    public float incrementAmount = 05.0f;
    public float decrementAmount = 10.0f;
	public Sprite full_charge;
	public Sprite semi_charge;
	List<Sprite> images = new List<Sprite>();
	public Sprite charge1;
	public Sprite charge2;
	public Sprite charge3;
	public Sprite charge4;
	public Sprite charge5;
	public Sprite charge6;
	public Sprite charge7;
	public Sprite charge8;
	public Sprite charge9;
	public float cooldown = 10.0f;
	public float animetime = -100.0f;
    RH_ScoreSystem ss;
    RH_RespawnPoint boss;
    RH_RespawnPoint boss2;
    RH_RespawnPoint boss3;
    public KeyCode activateOn = KeyCode.None;
	float energyBombThreshold = 75.0f;
	AudioSource attack;
	Animation bombAnim;


    UnityEngine.UI.Image img;
	float currentEnergy = 50.0f;

	void Start () {
        boss = GameObject.FindGameObjectWithTag("SpawnPt1").GetComponent<RH_RespawnPoint>();
        boss2 = GameObject.FindGameObjectWithTag("SpawnPt2").GetComponent<RH_RespawnPoint>();
        boss3 = GameObject.FindGameObjectWithTag("SpawnPt3").GetComponent<RH_RespawnPoint>();
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
		img = GetComponent<UnityEngine.UI.Image> ();
		img.fillAmount = currentEnergy / maxEnergy;
		attack = GetComponent<AudioSource> ();
		bombAnim = GameObject.FindGameObjectWithTag ("BombAnim").GetComponent<Animation>();
		images.Add(charge1);
		images.Add(charge2);
		images.Add(charge3);
		images.Add(charge4);
		images.Add(charge5);
		images.Add(charge6);
		images.Add(charge7);
		images.Add(charge8);
		images.Add(charge9);
	}

	float min(float a, float b){
		if (a <= b)
			return a;
		return b;
	}

	public void IncrementEnergy()
	{
		currentEnergy = min (currentEnergy + incrementAmount, maxEnergy);
		img.fillAmount = currentEnergy / maxEnergy;
		if (currentEnergy == maxEnergy)
		{
			this.transform.GetComponent<UnityEngine.UI.Image>().sprite = full_charge;
			for (int cnt = 0; cnt < images.Count; cnt++)
			{
				this.transform.GetComponent<UnityEngine.UI.Image>().sprite = images[cnt];

			}

			//StartCoroutine(Wait());
		}
	}

    public void DecrementEnergy()
    {
		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = semi_charge;
        currentEnergy = Mathf.Max(currentEnergy - decrementAmount, minEnergy);
        img.fillAmount = currentEnergy / maxEnergy;

		if (currentEnergy <= 0.0f) {
			FindObjectOfType<SceneController> ().SendMessage("GameOverLose");
		}
    }

	IEnumerator Wait()
	{
		this.transform.GetComponent<UnityEngine.UI.Image>().sprite = full_charge;
		yield return new WaitForSeconds(10f);
	}


    void Update () {

		if (Input.GetKeyDown(activateOn) && currentEnergy >= energyBombThreshold)
        {
            StartCoroutine(ActivateAttack());
        }
    }

	void DestroyWaves(string tag) {
		GameObject[] waves = GameObject.FindGameObjectsWithTag(tag);
		foreach(GameObject w in waves)
		{
			Destroy(w);
			ss.ModifyScore(100);
		}
	}

    IEnumerator ActivateAttack()
    {
		bombAnim.Play ();
		attack.Play ();
		DestroyWaves ("waveA");
		DestroyWaves ("waveB");
		DestroyWaves ("waveC");

        //boss.takeDamage(1);
        //boss2.takeDamage(1);
        //boss3.takeDamage(1);
        currentEnergy = 25.0f;
        img.fillAmount = currentEnergy / maxEnergy;


        yield return new WaitForSeconds(0.1f);
    }
}
