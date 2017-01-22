using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
	public KeyCode activateOn = KeyCode.None;
	public int activeTimeMillis = 100;
	public int combo_count;
	enum Version{waveA,waveB,waveC};
	Version myVersion;
	public bool miss; 
	GameObject player;

	public GameObject combo;

	SpriteRenderer render;
	Color activeColor;
	Color passiveColor;
	bool isActive = false;
	float timeElapsed = 0.0f;
	EnergyBarController eBar;

    RH_ScoreSystem ss;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Use this for initialization
	void Start () {
        ss = GameObject.FindGameObjectWithTag("ScoreSystem").GetComponent<RH_ScoreSystem>();
		eBar = FindObjectOfType<EnergyBarController> ();
		render = GetComponent<SpriteRenderer> ();
		activeColor = render.color;
		passiveColor = new Color(activeColor.r, activeColor.g, activeColor.b, 0);

	}

	void OnTriggerStay2D(Collider2D other) {
		if (isActive) {
			other.SendMessage ("OnBlock", SendMessageOptions.DontRequireReceiver);
			Debug.Log ("blocked");


			if ((other.tag == "waveA" && GetComponent<Transform>().tag == "ShieldA") || other.tag == "waveB" && GetComponent<Transform>().tag == "ShieldW" || other.tag == "waveC" && GetComponent<Transform>().tag == "ShieldD")//&& myVersion == Version.waveA)
			{
				Destroy (other.gameObject);
				eBar.IncrementEnergy ();
				ss.ModifyScore(100);
				combo_count += 1;
				miss = false;
			}
			else 
			{
				combo_count = 0;
			}

		/*	if (other.tag == "waveA" && GetComponent<Transform>().tag == "ShieldA")//&& myVersion == Version.waveA)
			{
				Debug.Log("Cancel wave A");
				Destroy (other.gameObject);
				eBar.IncrementEnergy ();
				ss.ModifyScore(100);
				combo_count += 1;
			}
			if (other.tag == "waveB" && GetComponent<Transform>().tag == "ShieldW")//myVersion == Version.waveB)
			{
				Debug.Log("Cancel wave B");
				Destroy(other.gameObject);
				eBar.IncrementEnergy ();
				ss.ModifyScore(100);
				combo_count += 1;
			}
			if (other.tag == "waveC" && GetComponent<Transform>().tag == "ShieldD")//myVersion == Version.waveC)
			{
				Debug.Log("Cancel wave C");
				Destroy(other.gameObject);
				eBar.IncrementEnergy ();
				ss.ModifyScore(100);
				combo_count += 1;
			}
			//eBar.IncrementEnergy ();
            //ss.ModifyScore(100);
            */
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		combo_count = 0;
	}

	
	// Update is called once per frame
	void Update () {

		timeElapsed += Time.deltaTime;

		if (Input.GetKeyDown (activateOn)) {
			isActive = true;
			timeElapsed = 0.0f;
		}
		else if (timeElapsed > activeTimeMillis / 1000.0f) {
			isActive = false;
		}

		//isActive = Input.GetKeyDown (activateOn);

		if (isActive) {
			render.color = activeColor;
		} else {
			render.color = passiveColor;
		}
	}
}
