using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageScrollAnimationScript : MonoBehaviour {

    public float scrollSpeed = 0.5F;
    private RawImage image;

    void Start()
    {
        image = GetComponent<RawImage>();
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        Rect uvRect = new Rect(offset, 0, 1, 1);
        image.uvRect = uvRect;        
    }
}
