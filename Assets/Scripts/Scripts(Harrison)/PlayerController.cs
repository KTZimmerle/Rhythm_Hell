using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	EnergyBarController eBar;
	public bool miss; 
	GameObject player;
	ShieldController shieldA;
	ShieldController shieldB;
	ShieldController shieldC;
	AudioSource damaged;
	SpriteRenderer playerRender;
	SpriteRenderer damagedRender;
	public Sprite damagedPlayer;
	Animator sAnim;
	bool wasHit = false;
	float timeElapsed = 0.0f;
	float timeDamaged = 0.5f;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		shieldA = player.transform.GetChild(1).GetComponentInChildren<ShieldController>();
		shieldB = player.transform.GetChild(2).GetComponentInChildren<ShieldController>();
		shieldC = player.transform.GetChild(3).GetComponentInChildren<ShieldController>();
		damaged = GetComponent<AudioSource> ();
		playerRender = GameObject.FindGameObjectWithTag ("PlayerSprite").GetComponent<SpriteRenderer>();
		damagedRender = GameObject.FindGameObjectWithTag ("PlayerSpriteDamaged").GetComponent<SpriteRenderer>();
		//sAnim = GameObject.FindGameObjectWithTag ("PlayerSprite").GetComponent<Animator>();
	}

	void Start () {
		eBar = FindObjectOfType<EnergyBarController> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("player hit");
		Destroy (other.gameObject);
		eBar.DecrementEnergy ();
		//also reduce the energy bar if hit
		miss = true; 

		damaged.Play ();
		//sAnim.Stop ();
		playerRender.enabled = false;
		damagedRender.enabled = true;
		wasHit = true;
		timeElapsed = 0.0f;
	}

	void Update () {
		if (shieldA.miss == false && shieldB.miss == false && shieldB.miss == false)
		{
			miss = false;
		}
		else
		{
			shieldA.combo_count = 0;
			shieldB.combo_count = 0;
			shieldC.combo_count = 0;
			miss = true;
		}

		if (wasHit) {
			timeElapsed += Time.deltaTime;

			if (timeElapsed >= timeDamaged) {
				//sAnim.Play ("Player Sprite Animation");
				playerRender.enabled = true;
				damagedRender.enabled = false;
			}
		}
	}
}
