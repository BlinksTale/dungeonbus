using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rendererFlicker : MonoBehaviour {

	float loop = .4f;
	Graphic graphic;

	// Use this for initialization
	void Start () {
		graphic = this.GetComponent<Graphic>();
	}
	
	// Update is called once per frame
	void Update () {
		bool intendedState = Time.realtimeSinceStartup % loop > loop/2f;
		if (intendedState != graphic.enabled)
		{
			graphic.enabled = intendedState;
		}
	}
}
