using UnityEngine;
using System.Collections;

public class BusController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody.AddTorque(new Vector3(0f, -2000f, 100f));
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody.AddTorque(new Vector3(0f, 2000f, -100f));
		}

	}
	
}
