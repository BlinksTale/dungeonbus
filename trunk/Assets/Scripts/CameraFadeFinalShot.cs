using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFadeFinalShot : MonoBehaviour {

	public Graphic panel;
	public float fadeInDelay = 3f;
	public float fadeInTime = 3f;
	public float visibleWait = 3f;
	public float fadeOutTime = 3f;
	public float fadeOutDelay = 3f;
	public string nextLevel;

	private float[] nodes;

	// Use this for initialization
	void Start () {
		panel.color = Color.black;
		nodes = new float[5];
		nodes[0] = fadeInDelay;
		nodes[1] = nodes[0] + fadeInTime;
		nodes[2] = nodes[1] + visibleWait;
		nodes[3] = nodes[2] + fadeOutTime;
		nodes[4] = nodes[3] + fadeOutDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > nodes[0] && Time.timeSinceLevelLoad < nodes[1]) {
			Color intended = Color.black;
			intended.a = (nodes[1] - Time.timeSinceLevelLoad) / fadeInTime;
			if (panel.color != intended) {
				panel.color = intended;
			}
		} else if (Time.timeSinceLevelLoad > nodes[2] && Time.timeSinceLevelLoad < nodes[3]) {
			Color intended = Color.black;
			intended.a = 1f - (nodes[3] - Time.timeSinceLevelLoad) / fadeInTime;
			if (panel.color != intended) {
				panel.color = intended;
			}
		} else if (Time.timeSinceLevelLoad >= nodes[4]) {
			Application.LoadLevel(nextLevel);
		}
	}
}
