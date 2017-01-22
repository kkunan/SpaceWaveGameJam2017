using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSplashScreen : MonoBehaviour
{
    private Image image;
    private float speed = 100;
	// Use this for initialization
	void Start ()
	{
	    image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Color color = image.color;
	    image.color = new Color(color.r, color.g, color.b, color.a += Time.deltaTime*speed);

        Debug.Log(image.color.a);

        if (image.color.a >= 255)
	    {
            Debug.Log("load scene");
	        SceneManager.LoadScene("test");

	    }
	}
}
