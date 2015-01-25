using UnityEngine;
using System.Collections;

public class DestroySelfAfter : MonoBehaviour {

	public float time = 1f;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup - startTime > time)
		{
			Destroy(this.gameObject);
		}
	}
}
