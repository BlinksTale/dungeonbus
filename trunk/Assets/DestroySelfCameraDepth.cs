using UnityEngine;
using System.Collections;

public class DestroySelfCameraDepth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.farClipPlane < 0.5f) {
			Destroy(this.gameObject);
		}
	}
}
