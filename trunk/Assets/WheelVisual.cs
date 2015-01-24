using UnityEngine;
using System.Collections;

public class WheelVisual : MonoBehaviour {

	public WheelCollider wheel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.localEulerAngles.y != wheel.steerAngle)
		{
			Vector3 newAngles = this.transform.localEulerAngles;
			newAngles.y = wheel.steerAngle;
			this.transform.localEulerAngles = newAngles;
		}
	}
}
