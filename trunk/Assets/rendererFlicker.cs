using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rendererFlicker : MonoBehaviour {

	float loop = .4f;
	Text text;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		bool intendedState = Time.realtimeSinceStartup % loop > loop/2f;
		if (intendedState != text.enabled)
		{
			text.enabled = intendedState;
		}
	}
}
