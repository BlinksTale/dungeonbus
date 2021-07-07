using UnityEngine;
using System.Collections;

public class EnableDisableButton : MonoBehaviour {

	public GameObject enableObj, disableObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void EnableDisable () {
		enableObj.SetActive(true);
		disableObj.SetActive(false);
	}
}
