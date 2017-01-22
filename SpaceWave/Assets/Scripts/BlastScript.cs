using UnityEngine;
using System.Collections;

public class BlastScript : MonoBehaviour {

	// Use this for initialization
    private float ttl;
    private float initialTtl = 2;
    private float scaleSpeed = 0.1f;
	void Start ()
	{

	    ttl = initialTtl;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    ttl -= Time.deltaTime;
        gameObject.transform.localScale += Vector3.one*scaleSpeed*Time.deltaTime;

        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
        Color myColor = rend.color;
        myColor.a = ttl / initialTtl;
        rend.color = myColor;

        if (ttl<0)
            Destroy(gameObject);

	}
}
