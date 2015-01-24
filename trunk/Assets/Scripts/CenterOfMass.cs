using UnityEngine;
using System.Collections;

public class CenterOfMass : MonoBehaviour {

	public Vector3 centerOfMass;

	// Use this for initialization
	void Start () {
		rigidbody.centerOfMass = centerOfMass;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
