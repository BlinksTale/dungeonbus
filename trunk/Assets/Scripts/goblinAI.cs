using UnityEngine;
using System.Collections;

public class goblinAI : MonoBehaviour {
	private GameObject bus;
	public float moveSpeed = 500f;

	private float range = 400f;

    private bool ragDollTime;
    private Rigidbody[] rigidBodies;
    private Vector3 targetPosition;
    private Animator anim;

	void Start () 
	{
		if (bus == null) 
		{
			bus = GameObject.FindWithTag("Player");
		}

        rigidBodies = this.GetComponentsInChildren<Rigidbody>();

        anim = this.GetComponent<Animator>();

        ToggleRagDoll(false);
	}

    void ToggleRagDoll(bool state)
    {
        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = !state;
        }
    }

	void Update () 
	{
        if (!ragDollTime)
        {

            targetPosition = bus.transform.position;
			if ((this.transform.position - targetPosition).magnitude < range*2f)
			{
				transform.LookAt(targetPosition);
			}

			if (this.transform.position != targetPosition && (this.transform.position - targetPosition).magnitude < range)
            {
                transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetPosition.x, this.transform.position.y, targetPosition.z), moveSpeed * Time.deltaTime);
                transform.LookAt(targetPosition);
            }
        }
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "sword" || col.gameObject.tag == "shield")
		{
			//Destroy(this.gameObject);
            Debug.Log("Hit Goblin");
            anim.enabled = false;
            ragDollTime = true;
            this.rigidbody.AddExplosionForce(1000f, this.transform.position, 10f);
            ToggleRagDoll(true);
		}
	}
}
