using UnityEngine;
using System.Collections;

public class SuddenlyReduceClippingPlane : MonoBehaviour {

	float delay = 18f;
	float reduction = 2f;
	float blackPause = 5f;
	float startingNear, startingFar;

	// Use this for initialization
	void Start () {
		startingNear = Camera.main.nearClipPlane;
		startingFar = Camera.main.farClipPlane;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeSinceLevelLoad > delay) 
		{
			if (Time.timeSinceLevelLoad < delay + reduction) {
				if (Camera.main.farClipPlane > startingNear) {
					Camera.main.farClipPlane = startingNear + (startingFar - startingNear) * (delay + reduction - Time.timeSinceLevelLoad) / reduction; 
//				} else if (Camera.main.nearClipPlane != 0.01f) {
//					Camera.main.farClipPlane = 0.02f;
//					Camera.main.nearClipPlane = 0.01f;
//				} else if (Camera.main.enabled) {
//					Camera.main.enabled = false;
				}
			} else {
				if (Camera.main.nearClipPlane != 0.01f) {
					Camera.main.farClipPlane = 0.02f;
					Camera.main.nearClipPlane = 0.01f;
				}
//				if (Camera.main && Camera.main.enabled) {
//					Camera.main.enabled = false;
//				}
			}

			if (Time.timeSinceLevelLoad > delay + reduction + blackPause)
			{
				Application.LoadLevel(0);
			}
		}
	}
}
