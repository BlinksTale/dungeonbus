using UnityEngine;
using System.Collections;

public class physicsSpawner : MonoBehaviour {
	public GameObject physicsObject;
	public GameObject[] physicsSpawners;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			foreach(GameObject spawner in physicsSpawners)
			{
				GameObject.Instantiate(physicsObject, spawner.transform.position, spawner.transform.rotation);
			}
		}
	}
}
