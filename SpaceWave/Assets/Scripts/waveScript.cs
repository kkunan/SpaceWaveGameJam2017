using UnityEngine;
using System.Collections;



public class WaveScript : MonoBehaviour {

    public int waveType; //default
    private float ttl = 2f;

    // Use this for initialization
    void Start ()
    {
        ttl = 2f;
    }
	
	// Update is called once per frame
	void Update ()
	{
        ttl -= Time.deltaTime;
	    if(ttl<0)
            Destroy(gameObject);
        this.transform.localScale+=new Vector3(0.05f,0,0);

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
                asteroid.Impact();
            }
            else
       //     Debug.Log("not equal " + asteroid.asteroidType + " " + waveType);
            Destroy(gameObject);
        }
    }
}
