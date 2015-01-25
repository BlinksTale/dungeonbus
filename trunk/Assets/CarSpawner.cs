using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public int frameSkip = 5;
    public float CarSpeed = 5;

    private CarEnemy carSpawn;

	// Use this for initialization
	void Start ()
    {
  
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.frameCount % frameSkip == 0)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        GameObject go;
        go = (GameObject)GameObject.Instantiate(car, this.transform.position, this.transform.rotation);
        carSpawn = go.GetComponent<CarEnemy>();
        carSpawn.speed = CarSpeed;
    }
}
