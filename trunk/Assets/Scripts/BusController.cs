using UnityEngine;
using System.Collections;
using System;

public class BusController : MonoBehaviour {

    public GameObject[] upgrades;
	public bool generatingGnomes = true;
    public GameObject gnome;
    public GameObject frontGnomeCage;
    public GameObject backGnomeCage;
    public Texture[] gnomeColors;
    public int gnomeCount = 15;
	public bool zeroGravity = false;
	private int selectedUpgrade;
    private int activeUpgrade;
	private GameObject front;

	// Use this for initialization
	void Start ()
    {
        DisableUpgrades();
		if (generatingGnomes) {
        	GenerateGnomes();
		}
		front = this.GetComponentInChildren<GrenadeLauncher>().gameObject;
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftArrow)) {
			front.rigidbody.AddRelativeTorque(new Vector3(-1000f, 0f, 0f));
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			front.rigidbody.AddRelativeTorque(new Vector3(1000f, 0f, 0f));
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
//        StartCoroutine(DisableUpgrade());
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
