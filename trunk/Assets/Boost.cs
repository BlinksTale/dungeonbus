using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour
{

    private WheelController[] wheelCons;

    public float boostSpeed = 2000f;
    private float origSpeed;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            wheelCons = col.gameObject.GetComponentsInChildren<WheelController>();

            foreach (WheelController wc in wheelCons)
            {
               //col.rigidbody.AddRelativeForce(new Vector3(0, 100f, 0), ForceMode.Impulse);
                origSpeed = wc.speed;
                wc.speed += boostSpeed;
            }

            this.collider.enabled = false;
            StartCoroutine(DisableBoost());
            
        }
    }

    IEnumerator DisableBoost()
    {
        yield return new WaitForSeconds(.5f);

        foreach (WheelController wc in wheelCons)
        {
            wc.speed = origSpeed;
        }

    }

}
