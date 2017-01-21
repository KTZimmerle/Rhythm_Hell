using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarController : MonoBehaviour {
	public float maxEnergy = 100.0f;
	public float incrementAmount = 10.0f;

	UnityEngine.UI.Image img;
	float currentEnergy = 0.0f;

	void Start () {
		img = GetComponent<UnityEngine.UI.Image> ();
		img.fillAmount = currentEnergy / maxEnergy;
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

	void Update () {
	}
}
