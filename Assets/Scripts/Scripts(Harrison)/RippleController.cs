using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleController : MonoBehaviour {
	Animation anim;
	float timeElapsed = 0.0f;
	float timeToDestroy = 2.0f;

	// Use this for initialization
	void Start () {
		transform.parent.DetachChildren ();
		anim = GetComponent<Animation> ();
		//anim.wrapMode = WrapMode.Once;
		//anim.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > timeToDestroy) {
			Destroy (gameObject);
		}
	}
}
