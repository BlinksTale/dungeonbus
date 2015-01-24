using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TreasureChest : MonoBehaviour
{

    private Animator anim;
    private Follow camFollow;
    private Rigidbody[] chestPieces;

	// Use this for initialization
	void Awake ()
    {
        anim = this.GetComponent<Animator>();
        camFollow = GameObject.FindWithTag("Follow").GetComponent<Follow>();

        chestPieces = this.GetComponentsInChildren<Rigidbody>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //camFollow.animOverride = true;
            anim.SetTrigger("ChestOpen");
            DOTween.To(() => camFollow.rotationOffset, x => camFollow.rotationOffset = x, new Vector3(0, -90, 0), 1);
        }

    }


}
