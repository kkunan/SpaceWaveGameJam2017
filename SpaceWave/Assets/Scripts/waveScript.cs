using UnityEngine;
using System.Collections;



public class WaveScript : MonoBehaviour {

    public int waveType = 1; //default

    // Use this for initialization
    void Start ()
    {
        waveType = 1;

    }
	
	// Update is called once per frame
	void Update ()
	{

        this.transform.localScale+=new Vector3(0.001f,0,0);

	}
}
