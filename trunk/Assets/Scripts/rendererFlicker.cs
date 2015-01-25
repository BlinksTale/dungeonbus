using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rendererFlicker : MonoBehaviour {

	public float loop = .4f;
	public float timeOff = .2f;
	Graphic graphic;
	float enabledTime;

	// Use this for initialization
	void Start () {
		graphic = this.GetComponent<Graphic>();
		enabledTime = Time.realtimeSinceStartup + timeOff;
	}
	
	// Update is called once per frame
	void Update () {
		bool intendedState = (Time.realtimeSinceStartup - enabledTime) % loop > timeOff;
		if (intendedState != graphic.enabled)
		{
			graphic.enabled = intendedState;
		}
	}
}
