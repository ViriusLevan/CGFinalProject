using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM5 : MonoBehaviour {

	// Use this for initialization
	// List<float> whichNote = new List<float>() {1,2,3,4,2,5,2,1,2,3,5,4,4,3,5,5,1,2,4,1,1,4,5,5,1,2,3,4,2,5,2,1,2,3,5,4,4,3,5,5,1,2,4,1,1,4,5,5,1,2,3,4,2,5,2,1,2,3,5,4,4,3,5,5,1,2,4,1,1,4,5,5,1,2,3,4,2,5,2,1,2,3,5,4,4,3,5,5,1,2,4,1,1,4,5,5};
	List<float> whichNote = new List<float>() {0,0,0,1,0,1,2,3,0,5,4,0,4,3,2,1,0,0,0,1,2,3,5,4,0,0,1,0,2,3,5,4,0,0,0,1,0,1,2,3,0,5,4,0,4,3,2,1,0,0,0,1,2,3,5,4,0,0,1,0,2,3,5,4,0,0,0,1,0,1,2,3,0,5,4,0,4,3,2,1,0,0,0,1,2,3,5,4,0,0,1,0,2,3,5,4,0,0,0,1,0,1,2,3,0,5,4,0,4,3,2,1,0,0,0,1,2,3,5,4,0,0,1,0,2,3,5,4,0,0,0,0,1,0,1,0,1,0,1,0,2,0,2,0,2,0,2,0,3,0,3,0,3,0,3,0,4,0,4,0,4,0,4,0,5,0,5,0,5,0,5,0,1,0,1,0,2,0,2,0,3,0,3,0,4,0,4,0,5,0,5,0,3,0,3,0};
	//List<float> whichNote = new List<float>() {1,2,3,4};
	public int noteMark =0, combo=0;
	public Transform noteObj;
	public string timerReset="y";
	public float xPos, score, delayScorePane=3;
	public GameObject[] notePerfectColliders, noteGoodColliders, noteBadColliders;
	public GameObject perfectText, goodText, badText, missedText, comboText, scoreText, scorePanel, finalScoreText, pausePanel;
	private string activeText;
	private Text txtFinalScore;
	private bool qPress, wPress, ePress, rPress, tPress, isPaused = false;
	private TextMesh comboTextMesh, scoreTextMesh;


	void Start () {

		scorePanel = GameObject.Find("Score Panel");
		finalScoreText = GameObject.Find ("Final Score Text");
		scorePanel.SetActive (false);
		pausePanel = GameObject.Find ("Pause Panel");
		pausePanel.SetActive (false);

		comboTextMesh = comboText.GetComponent(typeof(TextMesh)) as TextMesh;
		scoreTextMesh = scoreText.GetComponent(typeof(TextMesh)) as TextMesh;

		foreach(GameObject g in notePerfectColliders){
			g.gameObject.SetActive(false);
		}
		foreach(GameObject g in noteGoodColliders){
			g.gameObject.SetActive(false);
		}
		foreach(GameObject g in noteBadColliders){
			g.gameObject.SetActive(false);
		}
		perfectText.gameObject.SetActive(false);
		missedText.gameObject.SetActive(false);
		badText.gameObject.SetActive(false);
		goodText.gameObject.SetActive(false);
		qPress = wPress = ePress = rPress = tPress = false;
	}


	// Update is called once per frame
	void Update ()
	{
		if (noteMark == whichNote.Count) {
			//Move to result screen
			delayScorePane -= Time.deltaTime;
			if (delayScorePane <= 0f) {
				scorePanel.SetActive (true);
				(finalScoreText.GetComponent<Text> ()).text = "YOUR SCORE : "+ (int)score;

			}
		}
		else if (timerReset == "y") {
			StartCoroutine (spawnNote ());
			timerReset = "n";
		}

		if (Time.timeScale == 1) {
			if (Input.GetKeyDown ("q") && !qPress) {
				if (notePerfectColliders [0].gameObject.activeSelf == false) {
					qPress = true;
					StartCoroutine (qPressed ());
				}
			}
			//		if (Input.GetKeyUp ("q")) {
			//		}
			if (Input.GetKeyDown ("w") && !wPress) {
				if (notePerfectColliders [1].gameObject.activeSelf == false) {
					wPress = true;
					StartCoroutine (wPressed ());
				}
			}
			//		if (Input.GetKeyUp ("w")) {
			//		}
			if (Input.GetKeyDown ("e") && !ePress) {
				if (notePerfectColliders [2].gameObject.activeSelf == false) {
					ePress = true;
					StartCoroutine (ePressed ());
				}
			}
			//		if (Input.GetKeyUp ("e")) {
			//		}
			if (Input.GetKeyDown ("r") && !rPress) {
				if (notePerfectColliders [3].gameObject.activeSelf == false) {
					rPress = true;
					StartCoroutine (rPressed ());
				}
			}
			//		if (Input.GetKeyUp ("r")) {
			//		}
			if (Input.GetKeyDown ("t") && !tPress) {
				if (notePerfectColliders [4].gameObject.activeSelf == false) {
					tPress = true;
					StartCoroutine (tPressed ());
				}
			}
			//		if (Input.GetKeyUp ("t")) {
			//		}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Time.timeScale == 1) {
				pausePanel.SetActive (true);
				Time.timeScale = 0;
				isPaused = true;
			}else {
				pausePanel.SetActive (false);
				Time.timeScale = 1;
				isPaused = false;
			}
		}
	}

	IEnumerator spawnNote ()
	{
		if (!isPaused) {
			yield return new WaitForSeconds (0.215f);

			if	(whichNote[noteMark]!=0){
				if (whichNote [noteMark] == 1) {
					xPos = -4;//leftmost note
				} else if (whichNote [noteMark] == 2) {
					xPos = -2;
				} else if (whichNote [noteMark] == 3) {
					xPos = 0;
				} else if (whichNote [noteMark] == 4) {
					xPos = 2;
				} else if (whichNote [noteMark] == 5) {
					xPos = 4;
				}
				Debug.Log (xPos);
				// noteMark += 1;
				Instantiate (noteObj, new Vector3 (xPos, 5.0f, -4.25f), noteObj.rotation);
			}
			noteMark += 1;
			timerReset = "y";

		}
	}

	IEnumerator qPressed(){
		notePerfectColliders [0].gameObject.SetActive (true);
		noteGoodColliders [0].gameObject.SetActive (true);
		noteGoodColliders [5].gameObject.SetActive (true);
		noteBadColliders [0].gameObject.SetActive (true);
		noteBadColliders [5].gameObject.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		notePerfectColliders [0].gameObject.SetActive (false);
		noteGoodColliders [0].gameObject.SetActive (false);
		noteGoodColliders [5].gameObject.SetActive (false);
		noteBadColliders [0].gameObject.SetActive (false);
		noteBadColliders [5].gameObject.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		qPress = false;
	}

	IEnumerator wPressed(){
		notePerfectColliders [1].gameObject.SetActive (true);
		noteGoodColliders [1].gameObject.SetActive (true);
		noteGoodColliders [6].gameObject.SetActive (true);
		noteBadColliders [1].gameObject.SetActive (true);
		noteBadColliders [6].gameObject.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		notePerfectColliders [1].gameObject.SetActive (false);
		noteGoodColliders [1].gameObject.SetActive (false);
		noteGoodColliders [6].gameObject.SetActive (false);
		noteBadColliders [1].gameObject.SetActive (false);
		noteBadColliders [6].gameObject.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		wPress = false;
	}

	IEnumerator ePressed(){
		notePerfectColliders [2].gameObject.SetActive (true);
		noteGoodColliders [2].gameObject.SetActive (true);
		noteGoodColliders [7].gameObject.SetActive (true);
		noteBadColliders [2].gameObject.SetActive (true);
		noteBadColliders [7].gameObject.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		notePerfectColliders [2].gameObject.SetActive (false);
		noteGoodColliders [2].gameObject.SetActive (false);
		noteGoodColliders [7].gameObject.SetActive (false);
		noteBadColliders [2].gameObject.SetActive (false);
		noteBadColliders [7].gameObject.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		ePress = false;
	}

	IEnumerator rPressed(){
		notePerfectColliders [3].gameObject.SetActive (true);
		noteGoodColliders [3].gameObject.SetActive (true);
		noteGoodColliders [8].gameObject.SetActive (true);
		noteBadColliders [3].gameObject.SetActive (true);
		noteBadColliders [8].gameObject.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		notePerfectColliders [3].gameObject.SetActive (false);
		noteGoodColliders [3].gameObject.SetActive (false);
		noteGoodColliders [8].gameObject.SetActive (false);
		noteBadColliders [3].gameObject.SetActive (false);
		noteBadColliders [8].gameObject.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		rPress = false;
	}

	IEnumerator tPressed(){

		notePerfectColliders [4].gameObject.SetActive (true);
		noteGoodColliders [4].gameObject.SetActive (true);
		noteGoodColliders [9].gameObject.SetActive (true);
		noteBadColliders [4].gameObject.SetActive (true);
		noteBadColliders [9].gameObject.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		notePerfectColliders [4].gameObject.SetActive (false);
		noteGoodColliders [4].gameObject.SetActive (false);
		noteGoodColliders [9].gameObject.SetActive (false);
		noteBadColliders [4].gameObject.SetActive (false);
		noteBadColliders [9].gameObject.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		tPress = false;
	}

	public void setTextActive (string name){
		if (activeText != name) {

			if(activeText == "Perfect"){
				perfectText.SetActive (false);
				}else if(activeText == "Good"){
					goodText.SetActive(false);
					}else if(activeText == "Bad"){
						badText.SetActive(false);
						}else if(activeText == "Missed"){
							missedText.SetActive (false);
						}

						if (name == "Perfect") {
							perfectText.SetActive (true);
							activeText = "Perfect";
							}else if(name == "Good"){
								goodText.SetActive(true);
								activeText = "Good";
								}else if(name == "Bad"){
									badText.SetActive(true);
									activeText = "Bad";
									}else if (name == "Missed") {
										missedText.SetActive (true);
										activeText = "Missed";
									}
								}
							}

							public void editScore (int modifier)
							{
								if (modifier < 5) {
									combo = 0;
									comboTextMesh.text ="";
								} else {
									combo = combo + 1;
			comboTextMesh.text = ""+(combo/2);//bugged
		}
		Debug.Log("Modifier :" +modifier+ "\n Combo:"+combo);
		score += modifier + (0.1f * combo);
		if(score<0)score =0;
		scoreTextMesh.text = "Score\n"+ ((int)score);
	}
}
