using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TreasureChest : MonoBehaviour
{

    private Animator anim;
    private Follow camFollow;

	// Use this for initialization
	void Awake ()
    {
        anim = this.GetComponent<Animator>();
        camFollow = GameObject.FindWithTag("Follow").GetComponent<Follow>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //camFollow.animOverride = true;

            anim.SetTrigger("ChestOpen");
            
            //DOTween.To(() => camFollow.rotationOffset, x => camFollow.rotationOffset = x, new Vector3(0, -90, 0), 1);
        }

    }


}
