﻿using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform focus;
	public bool x,y,z;
	public bool exactly;
    public Vector3 rotationOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPos = this.transform.position;
		if (x)
		{
			newPos.x = focus.position.x;
		}
		if (y)
		{
			newPos.y = focus.position.y;
		}
		if (z)
		{
			newPos.z = focus.position.z;
		}

		if (exactly)
		{
			if (newPos != this.transform.position)
			{
				this.transform.position = newPos;
			}
		} else {
			newPos = this.transform.position * 0.9f + 0.1f*newPos;
			if (Mathf.Abs ((newPos - this.transform.position).magnitude) > .01f)
			{
				this.transform.position = this.transform.position * 0.8f + 0.2f * newPos;
			}
		}

        this.transform.rotation = Quaternion.Euler(rotationOffset);
	}
}
