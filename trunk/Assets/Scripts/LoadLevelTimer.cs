using UnityEngine;
using System.Collections;

public class LoadLevelTimer : MonoBehaviour {

	public string level;
	public float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad >= timer)
		{
			Application.LoadLevel(level);
		}
	}
}
