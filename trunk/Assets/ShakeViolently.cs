using UnityEngine;
using System.Collections;

public class ShakeViolently : MonoBehaviour {

	private Vector3 startingPosition;
	private float speed = 100f;
	private float scale = 2f;

	// Use this for initialization
	void Start () {
		startingPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPos = startingPosition;
		newPos.x += scale * Mathf.Sin (speed * Time.timeSinceLevelLoad) * Mathf.Pow (Time.timeSinceLevelLoad, 2f) / 100f;
		this.transform.position = newPos;
	}
}
