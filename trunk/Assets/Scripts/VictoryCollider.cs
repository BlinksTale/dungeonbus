using UnityEngine;
using System.Collections;

public class VictoryCollider : MonoBehaviour {

	public GameObject winText;
	private float timeToNextLevel = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player")
		{
			winText.SetActive(true);
			Invoke ("NextLevel", timeToNextLevel);
			collider.enabled = false;
		}
	}

	void NextLevel() {
		if (Application.loadedLevel < Application.levelCount - 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
