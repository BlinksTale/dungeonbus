using UnityEngine;
using System.Collections;

public class ClothConstantForce : MonoBehaviour {

	public Vector3 force;
	private InteractiveCloth cloth;

	// Use this for initialization
	void Start () {
		cloth = this.GetComponent<InteractiveCloth>();
	}
	
	// Update is called once per frame
	void Update () {
		cloth.AddForceAtPosition(force, this.transform.position, 100f);
	}
}
