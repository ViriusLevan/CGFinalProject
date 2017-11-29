using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

	public GM mainScript;

	// Use this for initialization
	void Start () {
		mainScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GM>();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(0,-0.1f,0);

	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.tag == "Perfect Collider") {
			mainScript.setTextActive("Perfect");
			Destroy(this.gameObject);
		}else if (other.gameObject.tag == "Good Collider") {
			mainScript.setTextActive("Good");
			Destroy(this.gameObject);
		}else if (other.gameObject.tag == "Bad Collider") {
			mainScript.setTextActive("Bad");
			Destroy(this.gameObject);
		}else if (other.gameObject.name == "Note Fail") {
			mainScript.setTextActive("Missed");
			Destroy(this.gameObject);
		}
	}
}
