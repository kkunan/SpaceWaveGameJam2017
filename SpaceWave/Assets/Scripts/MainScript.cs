﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    public GameObject station;
    public Text turnText;
    public Text scoreValueText;

    public Text resourcesValueText;

    public float score;
    
    public float resources;

    public GameObject asteroid;
    public float asteroidSpawnMinTime = 20; // seconds
    public float asteroidSpawnMaxTime = 50;
    private float asteroidSpawnCounter = 0;


    // Use this for initialization
    void Start ()
    {
        // stationScript = station.GetComponent<SpaceStationScript>();

        asteroidSpawnCounter = UnityEngine.Random.Range(asteroidSpawnMinTime, asteroidSpawnMaxTime);
    }
    
    // Update is called once per frame
    void Update ()
    {
        turnText.text = String.Format("Turn {0:F} degs", station.transform.rotation.eulerAngles.z);

        asteroidSpawnCounter -= Time.deltaTime;
        if (asteroidSpawnCounter < 0)
        {
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            float randomX = UnityEngine.Random.Range(-20f, 20f);
            float directionX = randomX/Mathf.Abs(randomX);
            float xPos = directionX*width/2 + randomX*(randomX/Mathf.Abs(randomX));

            float randomY = UnityEngine.Random.Range(-20f, 20f);
            float directionY = randomY / Mathf.Abs(randomX);
            float yPos = directionY * height / 2 + randomX * (randomX / Mathf.Abs(randomX));

			//spawn asteroids from 4 edges of screen
			Vector3 viewport=new Vector3();
			int direction = UnityEngine.Random.Range (0,4);
			if (direction == 0) {
				viewport = new Vector3 (0, UnityEngine.Random.Range (0f, 1f), 2);
				//print ("viewport 0: "+viewport.ToString());
			} else if (direction == 1) {
				viewport = new Vector3 (UnityEngine.Random.Range (0f, 1f),0, 2);
				//print ("viewport 1: "+viewport.ToString());
			} else if (direction == 2) {
				viewport = new Vector3 (1,UnityEngine.Random.Range (0f, 1f),2);
				//print ("viewport 2: "+viewport.ToString());
			} else if (direction == 3) {
				viewport = new Vector3 (UnityEngine.Random.Range (0f, 1f),1,2);
				//print ("viewport 3: "+viewport.ToString());
			}

			Vector3 spawnPos = Camera.main.ViewportToWorldPoint (viewport);

            //Spawn in the screen but not too close to center
            // Vector3 spawnPos = new Vector3(UnityEngine.Random.value*width, UnityEngine.Random.value*height - height/2, 0);

            Instantiate(asteroid, spawnPos, Quaternion.identity);
            Debug.Log("oh no an asteroid");
            asteroidSpawnCounter = UnityEngine.Random.Range(asteroidSpawnMinTime, asteroidSpawnMaxTime);


        }
    }

}