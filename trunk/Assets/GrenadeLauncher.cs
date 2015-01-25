using UnityEngine;
using System.Collections;

public class GrenadeLauncher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
		{
			FireGrenade(0f,1f,0f);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			FireGrenade(-1f,0f,0f);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			FireGrenade(0f,-1f,0f);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			FireGrenade(1f,0f,0f);
		}
	}

	void FireGrenade(float a, float b, float c)
	{
		float speed = 2000f;
		float dist = 10f;
		GameObject grenade = Instantiate(Resources.Load("Grenade")) as GameObject;
		grenade.transform.position = this.transform.position + new Vector3(a * dist, b * dist, c * dist);
		grenade.rigidbody.AddRelativeForce(new Vector3(a * speed, b * speed, c * speed));
	}
}
