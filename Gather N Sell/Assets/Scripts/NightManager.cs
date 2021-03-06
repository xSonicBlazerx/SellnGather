using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightManager : MonoBehaviour {

	public GameManager gameManager;

	public GameObject fading;
	public GameObject night;

	bool atPause = false;

	public Text wcoll;
	public Text bcoll;
	public Text ccoll;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (atPause && Input.GetKeyDown (KeyCode.Space))
			gameManager.ManagerDay ();
	}

	public void CompleteSceneNight(){
		fading.SetActive (true);
		night.SetActive (true);
		wcoll.text = Player.LumberSold.ToString ();
		bcoll.text = Player.BerrySold.ToString ();
		ccoll.text = Player.CoalSold.ToString ();
		atPause = true;
	}
		
}
