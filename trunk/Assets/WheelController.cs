using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {

	WheelCollider wheel;

	// Use this for initialization
	void Start () {
		wheel = (WheelCollider)collider;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			wheel.motorTorque = 1000f;
		} else {
			wheel.motorTorque = 10f;
		}
			
//		rigidbody.AddForce(new Vector3(0f, 0f, 1000f));
//		rigidbody.AddTorque(new Vector3(1000f, 1000f, 1000f));
	}
}
