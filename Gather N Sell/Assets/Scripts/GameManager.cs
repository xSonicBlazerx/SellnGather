﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	//AudioManager
	public GameObject audioManager;
	public GameObject soundEffectManager;
	public Player player;
	public Camera camera;

	//Day Variables
	public static int customersLeft = 15;
	float dayTimer = 180;
	float timeLeft;

	void Awake(){
		DontDestroyOnLoad (this);
		DontDestroyOnLoad (player);
		DontDestroyOnLoad (audioManager);
		DontDestroyOnLoad (soundEffectManager);
		DontDestroyOnLoad (camera);
	}

	// Use this for initialization
	void Start () {
		this.timeLeft = dayTimer;
		//Instantiate (player);
		if (SceneManager.GetActiveScene ().name == "StarterScene")
			Application.LoadLevel ("_Scenes/Day");
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		GameEnd ();
	}

	/**
	 * Checks whether the player is either out of time or customers.
	 * If so, then the day is over
	 * (NOTE: Still need to set up transition between day and night)
	 */
	void GameEnd(){
		if (customersLeft == 0 || this.timeLeft <= 0) {
			Debug.Log ("Day Over!!!");
			timeLeft = dayTimer;
			customersLeft = 15;
			//UnityEditor.EditorApplication.isPlaying = false;
			audioManager.GetComponent<AudioManager>().ChangeToNight();
			Application.LoadLevel("_Scenes/Workshop");
		}
	}
}
