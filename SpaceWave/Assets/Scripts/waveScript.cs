using UnityEngine;
using System.Collections;

public class waveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	    this.transform.localScale+=new Vector3(0.001f,0,0);

	}
}
