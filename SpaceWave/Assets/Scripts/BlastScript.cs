using UnityEngine;
using System.Collections;

public class BlastScript : MonoBehaviour {

	// Use this for initialization
    private float ttl;
	void Start ()
	{

	    ttl = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    ttl -= Time.deltaTime;
        gameObject.transform.localScale += new Vector3(0.2f,0.2f,0.2f); 

        if(ttl<0)
            Destroy(gameObject);

	}
}
