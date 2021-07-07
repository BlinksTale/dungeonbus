using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotatingDanceGraphic : MonoBehaviour {

	RectTransform gfx;
	// 84bpm? 80? 40x per minute is a good start, 40x per minute == 40/60x per second == 2/3
	float beatLength = 86f/120f;//.5f;
	public float rotationDist = 15f;

	// Use this for initialization
	void Start () {
		gfx = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		float intendedRotation = Time.timeSinceLevelLoad % (beatLength*2f) < beatLength ? -rotationDist : rotationDist;

		if (gfx.localEulerAngles.z != intendedRotation)
		{
			Vector3 newRotation = gfx.localEulerAngles;
			newRotation.z = intendedRotation;
			gfx.localEulerAngles = newRotation;
		}
	}
}
