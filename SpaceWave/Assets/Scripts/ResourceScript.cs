using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResourceScript : MonoBehaviour
{

	// Use this for initialization
    private float ttl;
    public float dragForce;
	void Start () {
        ttl = 30f;
    }
	
	// Update is called once per frame
	void Update () {

        ttl -= Time.deltaTime;

	    if (ttl < 0)
	    {
	        ScoreManager.Resource += 1;
       //     Debug.Log("resources "+ScoreManager.Resource);
	        Destroy(gameObject);
	    }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collided!!!!");
        if (other.gameObject.tag == "Wave")
        {
            if (other.gameObject.GetComponent<WaveScript>().waveType == 3)
            {
                Rigidbody2D body = GetComponent<Rigidbody2D>();

                //[TODO] if moving spaceStation, change this to spaceStation.pos - body.pos
                body.AddForce(new Vector2(-body.position.x,-body.position.y)*dragForce);

            }
        }

    }
}
