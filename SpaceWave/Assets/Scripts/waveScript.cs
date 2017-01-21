using UnityEngine;
using System.Collections;



public class waveScript : MonoBehaviour {

    private char waveType = 'd'; //default

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKey("1"))
        {
            //default, for destroy non-resource asteroids
            waveType = '1';
        }

        if (Input.GetKey("2"))
        {
            // for destroy resource ones
            waveType = '2';
        }

        if (Input.GetKey("3"))
        {
            //for collect the resource (drag inside while the wave hit resources (and asteroids?)
            waveType = '3';
        }

        this.transform.localScale+=new Vector3(0.001f,0,0);

	}
}
