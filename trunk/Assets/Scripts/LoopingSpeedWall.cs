using UnityEngine;
using System.Collections;

public class LoopingSpeedWall : MonoBehaviour {

	private Vector3 velocity = new Vector3(0f, 0f, -400f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position += velocity;
		if (this.transform.position.z < -25000)
		{
			this.transform.position += new Vector3(0f, 0f, 10000f * 6f); 
		}
	}
}
