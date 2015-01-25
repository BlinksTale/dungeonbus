﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryCollider : MonoBehaviour {

	public GameObject winObj;
	public Text gnomeText;
	private float timeToNextLevel = 3f;
	private int totalGnomes = 0;
	private bool winTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player" && !winTriggered)
		{
			WinLevel();
		}

		if (other.tag == "Gnome")
		{
			totalGnomes++;
			gnomeText.text = "" + totalGnomes;
			other.collider.enabled = false;
		}
	}

	void WinLevel() {
		winObj.SetActive(true);
		gnomeText.gameObject.SetActive(true);
		gnomeText.text = "" + totalGnomes;
		Invoke ("NextLevel", timeToNextLevel);
		winTriggered = true;
		audio.Play();
	}

	void NextLevel() {
		if (Application.loadedLevel < Application.levelCount - 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
