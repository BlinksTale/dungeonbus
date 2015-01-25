﻿using UnityEngine;
using System.Collections;
using System;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    public int frameSkip = 5;
    public float CarSpeed = 5;
    public Texture[] carColors;

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

        System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
        Renderer carRenderer;
        carRenderer = go.GetComponentInChildren<Renderer>();
        carRenderer.renderer.material.mainTexture = carColors[rand.Next(0, carColors.Length)];

        carSpawn = go.GetComponent<CarEnemy>();
        carSpawn.speed = CarSpeed;
    }
}
