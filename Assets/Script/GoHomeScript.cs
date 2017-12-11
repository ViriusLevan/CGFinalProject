using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void retry1() {
		SceneManager.LoadScene ("Play");
	}

	public void retry2() {
		SceneManager.LoadScene ("Play2");
	}

	public void retry3() {
		SceneManager.LoadScene ("Play3");
	}

	public void retry4() {
		SceneManager.LoadScene ("Play4");
	}

	public void retry5() {
		SceneManager.LoadScene ("Play5");
	}

	public void goHome() {
		SceneManager.LoadScene ("MainMenu");
	}
}
