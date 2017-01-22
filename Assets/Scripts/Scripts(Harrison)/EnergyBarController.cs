using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    public float maxEnergy = 100.0f;
    public float minEnergy = 0.0f;
    public float incrementAmount = 10.0f;
    public float decrementAmount = 10.0f;
	public Sprite full_charge;
	public Sprite semi_charge;

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

		if (currentEnergy >= maxEnergy)
		{
			this.transform.GetComponent<UnityEngine.UI.Image>().sprite = full_charge;
		}
		else if(currentEnergy < maxEnergy)
		{
			this.transform.GetComponent<UnityEngine.UI.Image>().sprite = semi_charge;
		}
	}

    public void DecrementEnergy()
    {
        currentEnergy = Mathf.Max(currentEnergy - decrementAmount, minEnergy);
        img.fillAmount = currentEnergy / maxEnergy;

		if (currentEnergy <= 0.0f) {
			FindObjectOfType<SceneController> ().SendMessage("GameOverLose");
		}
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

        boss.takeDamage(1);
        boss2.takeDamage(1);
        boss3.takeDamage(1);
        currentEnergy = 25.0f;
        img.fillAmount = currentEnergy / maxEnergy;


        yield return new WaitForSeconds(0.1f);
    }
}
