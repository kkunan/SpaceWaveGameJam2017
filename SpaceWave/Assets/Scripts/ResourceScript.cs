using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ResourceScript : MonoBehaviour
{

	// Use this for initialization
    private float ttl;
	void Start () {
        ttl = 3f;
    }
	
	// Update is called once per frame
	void Update () {

        ttl -= Time.deltaTime;

	    if (ttl < 0)
	    {
	        ScoreManager.Resource += 1;
            Debug.Log("resources "+ScoreManager.Resource);
	        Destroy(gameObject);
	    }

	}
}
