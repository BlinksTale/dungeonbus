using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public GameObject text;
	private float timeToNextLevel = 3f;
	bool lossTriggered = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (!lossTriggered && other.tag == "Player")
		{
			text.SetActive(true);
			audio.Play();
			Invoke ("Reset", timeToNextLevel);
			lossTriggered = true;
		}
		
		if (other.tag == "Gnome")
		{
			AudioSource otherAudio = other.transform.parent.audio;
			if (!otherAudio.isPlaying) {
				otherAudio.Play();
			}
			other.collider.enabled = false;
		}
	}
	
	void Reset() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
