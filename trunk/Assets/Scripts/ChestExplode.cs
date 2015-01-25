using UnityEngine;
using System.Collections;

public class ChestExplode : MonoBehaviour
{
    public GameObject[] meshGeo;
    private Rigidbody[] chestPieces;
    private BusController player;

    void Start()
    {
        chestPieces = this.GetComponentsInChildren<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.transform.parent.parent.parent.GetComponent<BusController>();
            player.EnableUpgrade();
            StartCoroutine(DisableColliders());

            foreach (Rigidbody rb in chestPieces)
            {
                rb.gameObject.renderer.enabled = true;
                rb.isKinematic = false;
            }

            foreach (GameObject obj in meshGeo)
            {
                obj.SetActive(false);
            }
        }

    }

    IEnumerator DisableColliders()
    {
        yield return new WaitForSeconds(.1f);

        this.collider.enabled = false;

        foreach (Rigidbody rb in chestPieces)
        {
            rb.collider.enabled = false;
        }

    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //
    //        foreach (Rigidbody rb in chestPieces)
    //        {
    //            rb.collider.enabled = false;
    //        }
    //
    //    }
    //
    //}
}

