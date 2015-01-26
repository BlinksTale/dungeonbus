using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform focus;
	public bool x,y,z;
	public bool exactly;
    public Vector3 rotationOffset;
    public Vector3 posOffset;
    public Camera altCam;
    public Camera mainCam;
    private bool flip;

	// Use this for initialization
	void Start ()
    {
        altCam = GameObject.FindWithTag("altCam").GetComponent<Camera>();
        mainCam = Camera.main;
	}

    void SwitchCam()
    {
        altCam.enabled = !altCam.enabled;
        mainCam.enabled = !mainCam.enabled;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPos = this.transform.position;
		if (x)
		{
			newPos.x = focus.position.x + posOffset.x;
		}
		if (y)
		{
            newPos.y = focus.position.y + posOffset.y;
		}
		if (z)
		{
            newPos.z = focus.position.z + posOffset.z;
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

        if (Input.GetKey(KeyCode.F) && flip==false)
            SwitchCam();
   
	}
}
