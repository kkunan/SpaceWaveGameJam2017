using UnityEngine;
using System.Collections;

public class AsteroidScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
        	Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 position = gameObject.transform.position;


        //random velocity
        // rb.AddForce(new Vector2(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10,10)), ForceMode2D.Impulse);

        rb.AddForce(new Vector2(-position.x, -position.y), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {


	
	}
}
