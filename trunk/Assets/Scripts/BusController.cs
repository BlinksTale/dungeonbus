using UnityEngine;
using System.Collections;
using System;

public class BusController : MonoBehaviour {

    public GameObject[] upgrades;
    public GameObject gnome;
    public GameObject frontGnomeCage;
    public GameObject backGnomeCage;
    public Texture[] gnomeColors;
    public ParticleSystem[] sparks;
    public int gnomeCount = 15;
    private int selectedUpgrade;
    private int activeUpgrade;
    [SerializeField]
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        DisableUpgrades();
        GenerateGnomes();
        ToggleSparks(false);
	}

    void ToggleSparks(bool state)
    {
        for (int i = 0; i < sparks.Length; i++)
        {
            if (state)
            {
                sparks[i].Emit(1);
            }
            else
            {
                sparks[i].Emit(0);
            }
        }
    }

    void FixedUpdate()
    {
  
        if (rb.velocity.magnitude > 20f)
        {
            ToggleSparks(true);
        }
        else
        {
            ToggleSparks(false);
        }
    }

    void GenerateGnomes()
    {
        for (int i = 0; i < gnomeCount; i++)
        {
            GameObject go = (GameObject)GameObject.Instantiate(gnome,this.transform.position,Quaternion.identity);

            System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
            Renderer gnomeRenderer;
            gnomeRenderer = go.GetComponentInChildren<Renderer>();
            gnomeRenderer.renderer.material.mainTexture = gnomeColors[rand.Next(0, gnomeColors.Length)];

            if (i < 7)
            {
                go.transform.parent = frontGnomeCage.transform;
                go.transform.localPosition = new Vector3(0 + i * 2, 0, 0);
            }
            else
            {
                go.transform.parent = backGnomeCage.transform;
                go.transform.localPosition = new Vector3(0 + (i - 7) * 2, 0, 0);
            }

            

           go.rigidbody.isKinematic = false;

        }

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
