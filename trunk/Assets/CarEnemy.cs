﻿using UnityEngine;
using System.Collections;

public class CarEnemy : MonoBehaviour
{
    public float speed = 5f;
	
	// Update is called once per frame
	void Update ()
    {
        //this.transform.position = new Vector3(this.transform.position.x + speed,
        //                                        this.transform.position.y,
        //                                        this.transform.position.z);
        rigidbody.AddRelativeForce(new Vector3(speed, 0, 0),ForceMode.Acceleration);
	}
}
