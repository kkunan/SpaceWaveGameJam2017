using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

	public GameObject station;
	public Text turnText;
	public Text scoreValueText;
	public Text livesValueText;
	public Text resourcesValueText;

	public float score;
	public float lives;
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

            Vector3 spawnPos = new Vector3(UnityEngine.Random.value*width - width/2, UnityEngine.Random.value*height - height/2, 0);
		    Instantiate(asteroid, spawnPos, Quaternion.identity);
			Debug.Log("oh no an asteroid");
			asteroidSpawnCounter = UnityEngine.Random.Range(asteroidSpawnMinTime, asteroidSpawnMaxTime);
		}
	}
}
