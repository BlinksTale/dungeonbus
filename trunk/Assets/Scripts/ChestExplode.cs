﻿using UnityEngine;
using System.Collections;

public class ChestExplode : MonoBehaviour
{
    public GameObject[] meshGeo;
    private Rigidbody[] chestPieces;

    void Start()
    {
        chestPieces = this.GetComponentsInChildren<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

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
