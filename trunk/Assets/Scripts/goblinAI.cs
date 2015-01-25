using UnityEngine;
using System.Collections;

public class goblinAI : MonoBehaviour {
	public GameObject bus;

	void Start () 
	{
		if (bus == null) 
		{
			bus = GameObject.FindWithTag("Player");
		}
	}

	void Update () 
	{
		this.transform.position += bus.transform.position/10;
	}
}
