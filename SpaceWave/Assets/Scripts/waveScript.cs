using UnityEngine;
using System.Collections;



public class WaveScript : MonoBehaviour {

    public int waveType; //default
    private float initialTtl = 2f;
    private float ttl;

    // Use this for initialization
    void Start ()
    {
        ttl = initialTtl;
    }
	
	// Update is called once per frame
	void Update ()
	{
        ttl -= Time.deltaTime;
	    if(ttl<0)
            Destroy(gameObject);
        this.transform.localScale+=new Vector3(0.05f,0.05f,0.02f);
	    SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
	    Color waveColor = rend.color;
	    waveColor.a = ttl/initialTtl;
	    rend.color = waveColor;

	    //   Debug.Log("wave type inside wave" + waveType);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            AsteroidScript asteroid = other.gameObject.GetComponent<AsteroidScript>();

            if (asteroid.asteroidType == waveType)
            {
       //         Debug.Log("equal "+asteroid.asteroidType+" "+waveType);
                asteroid.ImpactFromWave();
;

            }
          //  else
       //     Debug.Log("not equal " + asteroid.asteroidType + " " + waveType);
          //  Destroy(gameObject);
        }
    }
}
