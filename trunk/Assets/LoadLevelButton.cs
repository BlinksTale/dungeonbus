using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public string levelName = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void LoadLevel () {
		Debug.Log ("Mouse press detected");
		Application.LoadLevel(levelName);
	}
}
