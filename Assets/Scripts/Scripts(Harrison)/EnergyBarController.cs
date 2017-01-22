using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour
{
    public float maxEnergy = 100.0f;
    public float minEnergy = 0.0f;
    public float incrementAmount = 10.0f;
    public float decrementAmount = 10.0f;

    RH_ScoreSystem ss;
    RH_RespawnPoint boss;
    public KeyCode activateOn = KeyCode.None;
	float energyBombThreshold = 75.0f;
	AudioSource attack;

    UnityEngine.UI.Image img;
	float currentEnergy = 50.0f;

	void Start () {
        boss = GameObject.FindGameObjectWithTag("SpawnPt1").GetComponent<RH_RespawnPoint>();
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
		img = GetComponent<UnityEngine.UI.Image> ();
		img.fillAmount = currentEnergy / maxEnergy;
		attack = GetComponent<AudioSource> ();
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

		attack.Play ();
		DestroyWaves ("waveA");
		DestroyWaves ("waveB");
		DestroyWaves ("waveC");

        boss.takeDamage(2);
        currentEnergy -= 50.0f;
        img.fillAmount = currentEnergy / maxEnergy;


        yield return new WaitForSeconds(0.1f);
    }
}
