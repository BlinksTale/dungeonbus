using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {

	public bool steering = true;
	public bool invertDirection = false;
	public float speed = 20f;

	private WheelCollider wheel;
	private float turningSpeed = 3f; // speed of 2f has some good chunkiness
	private float steerAngleMax = 45f;

	private bool turnRight, turnLeft;

	// Use this for initialization
	void Start () {
		wheel = (WheelCollider)collider;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			wheel.motorTorque = 50f*speed;
		} else {
			wheel.motorTorque = 1f*speed;
		}

		if (steering) {
			turnLeft = 	(Input.GetKey (KeyCode.LeftArrow)  && !invertDirection) || 
						(Input.GetKey (KeyCode.RightArrow) && invertDirection);
			turnRight = (Input.GetKey (KeyCode.LeftArrow)  && invertDirection) || 
						(Input.GetKey (KeyCode.RightArrow) && !invertDirection);

			if (turnLeft && wheel.steerAngle > -steerAngleMax) {
				wheel.steerAngle -= turningSpeed;
			}
			if (turnRight && wheel.steerAngle < steerAngleMax) {
				wheel.steerAngle += turningSpeed;
			}
		}

//		rigidbody.AddForce(new Vector3(0f, 0f, 1000f));
//		rigidbody.AddTorque(new Vector3(1000f, 1000f, 1000f));
	}
}
