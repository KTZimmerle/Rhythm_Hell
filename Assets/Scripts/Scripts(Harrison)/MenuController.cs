using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public string sceneToLoad = "Harrison(Test)";

	void Start () {
		
	}

	void OnStart() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
	}

	void Update () {
		
	}
}
