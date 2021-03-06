﻿using UnityEngine;
using System.Collections;

public class goblinAI : MonoBehaviour {
	private GameObject bus;
	public float moveSpeed = 500f;
	public AudioClip deathAudio;

	private float range = 400f;

    private bool ragDollTime;
    private Rigidbody[] rigidBodies;
    private Collider[] colliders;
    private Vector3 targetPosition;
    private Animator anim;
    private int layerMask;

	void Start () 
	{
		if (bus == null) 
		{
			bus = GameObject.FindWithTag("Player");
		}

        rigidBodies = this.GetComponentsInChildren<Rigidbody>();
        colliders = this.GetComponentsInChildren<Collider>();

        anim = this.GetComponent<Animator>();

        layerMask = LayerMask.NameToLayer("goblin");

        ToggleRagDoll(false);

		audio.Stop();
		audio.PlayDelayed(Random.Range (0f,3f));

		// Still can't seem to randomize animation play position, this doesn't work either
//		anim.playbackTime = Random.Range (0f,3f);

	}

    void ToggleRagDoll(bool state)
    {
        foreach (Rigidbody rb in rigidBodies)
        {

            if (rb.gameObject.layer == layerMask)
            {
                rb.isKinematic = !state;
            }
        }


        foreach (Collider col in colliders)
        {
            if (col.gameObject.layer == layerMask)
            {
                col.enabled = state;
            }
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
    void OnCollisionEnter(Collision col)
	{

        if (col.gameObject.tag == "sword" || col.gameObject.tag == "shield")
		{
		//Destroy(this.gameObject);
            Debug.Log("Hit Goblin");
            anim.enabled = false;
            ragDollTime = true;
            collider.isTrigger = true;
            ToggleRagDoll(true);
			audio.clip = deathAudio;
			audio.loop = false;
			RandomizeAudioSource randAudio = this.GetComponent<RandomizeAudioSource>();
			randAudio.totalClips = 3;
			randAudio.RandomizeAudio();
			this.rigidbody.AddExplosionForce(1000f, this.transform.position, 10f);
           
		}
	}
}
