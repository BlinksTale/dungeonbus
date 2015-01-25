using UnityEngine;
using System.Collections;
using System;

public class BusController : MonoBehaviour {

    public GameObject[] upgrades;
    private int selectedUpgrade;
    private int activeUpgrade;
	// Use this for initialization
	void Start ()
    {
        DisableUpgrades();
	}

    public void EnableUpgrade()
    {
        StopCoroutine(DisableUpgrade());

        

        while(selectedUpgrade == activeUpgrade)
        {
            System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
            selectedUpgrade = rand.Next(0, upgrades.Length);
            //selectedUpgrade = Random.Range(0, upgrades.Length - 1);
            Debug.Log(selectedUpgrade);
        }

        

        upgrades[selectedUpgrade].SetActive(true);
        activeUpgrade = selectedUpgrade;
        StartCoroutine(DisableUpgrade());
    }

    IEnumerator DisableUpgrade()
    {
        yield return new WaitForSeconds(10f);
        DisableUpgrades();
    }

    void DisableUpgrades()
    {
        foreach (GameObject obj in upgrades)
        {
            obj.SetActive(false);
        }
    }
	
}
