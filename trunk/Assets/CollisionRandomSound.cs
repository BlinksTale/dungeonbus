using UnityEngine;
using System.Collections;

public class CollisionRandomSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		if (!audio.isPlaying &&
			(other.gameObject.tag == "Player" ||
 		     other.gameObject.tag == "sword" ||
		     other.gameObject.tag == "shield")) {
			audio.Play();
		}
	}
}
