using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void play1() {
		SceneManager.LoadScene ("Play");	
	}

	public void play2() {
		SceneManager.LoadScene ("Play2");	
	}

	public void play3() {
		SceneManager.LoadScene ("Play3");	
	}

	public void play4() {
		SceneManager.LoadScene ("Play4");	
	}

	public void play5() {
		SceneManager.LoadScene ("Play5");	
	}

	public void exitGame(){
		Application.Quit ();
	}
}
