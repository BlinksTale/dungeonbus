using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public GameObject text;
	private float timeToNextLevel = 3f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player")
		{
			text.SetActive(true);
			Invoke ("Reset", timeToNextLevel);
			collider.enabled = false;
		}
	}
	
	void Reset() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
