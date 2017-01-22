using UnityEngine;
using System.Collections;

public class BlastScript : MonoBehaviour {

	// Use this for initialization
    private float ttl;
    private float scaleSpeed = 0.1f;
	void Start ()
	{

	    ttl = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    ttl -= Time.deltaTime;
        gameObject.transform.localScale += Vector3.one*scaleSpeed*Time.deltaTime; 

        if(ttl<0)
            Destroy(gameObject);

	}
}
