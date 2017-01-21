using UnityEngine;
using System.Collections;



public class WaveScript : MonoBehaviour {

    public int waveType = 1; //default
    private float ttl = 2f;

    // Use this for initialization
    void Start ()
    {
        waveType = 1;
        ttl = 2f;
    }
	
	// Update is called once per frame
	void Update ()
	{
        ttl -= Time.deltaTime;
	    if(ttl<0)
            Destroy(this.gameObject);
        this.transform.localScale+=new Vector3(0.05f,0,0);

	}
}
