using UnityEngine;
using System.Collections;

public class goblinAI : MonoBehaviour {
	public GameObject bus;
	public float moveSpeed = 500f;

	private float range = 400f;

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
		if ((this.transform.position - targetPosition).magnitude < range*2f)
		{
			transform.LookAt(targetPosition);
		}
		if (this.transform.position != targetPosition && (this.transform.position - targetPosition).magnitude < range) 
		{
			transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetPosition.x, this.transform.position.y, targetPosition.z), moveSpeed*Time.deltaTime);
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "sword" || col.gameObject.tag == "shield")
		{
			Destroy(this.gameObject);
		}
	}
}
