using UnityEngine;
using System.Collections;

public class goblinAI : MonoBehaviour {
	public GameObject bus;
	public float moveSpeed = 500f;
	void Start () 
	{
		if (bus == null) 
		{
			bus = GameObject.FindWithTag("Player");
		}
	}

	void Update () 
	{
		Vector3 targetPosition = bus.transform.position;
		if (this.transform.position != targetPosition) 
		{
			transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetPosition.x, this.transform.position.y, targetPosition.z), moveSpeed*Time.deltaTime);
			transform.LookAt(targetPosition);
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "sword")
		{
			Destroy(this);
		}
	}
}
