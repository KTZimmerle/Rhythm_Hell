using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleController : MonoBehaviour {
	Animation anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		//anim.wrapMode = WrapMode.Once;
		//anim.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayAnimation() {
		anim.Play ();
	}
}
