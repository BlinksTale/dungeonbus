using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour
{

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = this.GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("ChestOpen");
        }
    }
}
