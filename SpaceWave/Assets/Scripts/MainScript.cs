﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

	public GameObject station;
	public Text scoreValueText;
	public Text resourcesValueText;
	public Text timeText;
	public Image turnIndicator;
    public RawImage waveTypeIndicator;

	public float score;
	
	public float resources;

	public float time;

	public GameObject asteroid;
	public float asteroidSpawnMinTime = 20; // seconds
	public float asteroidSpawnMaxTime = 50;
	private float asteroidSpawnCounter = 0;
	public GameObject wave;
	private SpaceStationScript stationScript;

	private WaveScript waveSc;
	private int waveType;

	private Color[] colors;

	// Use this for initialization
	void Start ()
	{
		stationScript = station.GetComponent<SpaceStationScript>();
		waveSc = wave.GetComponent<WaveScript>();
		asteroidSpawnCounter = UnityEngine.Random.Range(asteroidSpawnMinTime, asteroidSpawnMaxTime);

		waveType = 1;

		colors = new Color[]
		{
			Color.blue,
			Color.red, 
			Color.green 
		};

	    waveTypeIndicator.color = colors[waveType];
	}

	int waveTypeManager()
	{
		if (Input.GetKeyDown("1"))
		{
			//default, for destroy non-resource asteroids
			waveType = 1;
			Debug.Log("press 1" + waveType);
		}

		else if (Input.GetKeyDown("2"))
		{
			// for destroy resource ones
			waveType = 2;
			Debug.Log("press 2" + waveType);
		}

		else if (Input.GetKeyDown("3"))
		{
			//for collect the resource (drag inside while the wave hit resources (and asteroids?)
			waveType = 3;
			Debug.Log("press 3 "+waveType);
		}

        waveTypeIndicator.color = colors[waveType - 1];
        return waveType;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//turnText.text = String.Format("Turn {0:F} degs", station.transform.rotation.eulerAngles.z);
		turnIndicator.rectTransform.rotation = Quaternion.Euler(0, 0, station.transform.rotation.eulerAngles.z);



		Boolean click = stationScript.clicking;

		//      Debug.Log("passing click = "+click);
		int index = waveTypeManager() - 1;

		if (click)
		{

			Vector2 stationPos = station.transform.position;
			Vector2 rotateVector = station.transform.rotation * (Vector2.up);

			Vector2 newWavePos = stationPos + rotateVector * station.GetComponent<CircleCollider2D>().radius;

		   
			GameObject newWave = (GameObject)Instantiate(wave, newWavePos, station.transform.rotation);

			newWave.GetComponent<Rigidbody2D>().AddForce(new Vector2(newWavePos.x, newWavePos.y)*100);
			
			Color whateverColor = colors[index];

			Debug.Log(whateverColor);

			SpriteRenderer gameObjectRenderer = newWave.GetComponent<SpriteRenderer>();

			gameObjectRenderer.material.color = whateverColor;
			

		}

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
		   // Debug.Log("oh no an asteroid");
			asteroidSpawnCounter = UnityEngine.Random.Range(asteroidSpawnMinTime, asteroidSpawnMaxTime);


		}

		time += Time.deltaTime;
		timeText.text = Mathf.FloorToInt(time) + "";
	}

}
