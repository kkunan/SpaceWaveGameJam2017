using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Lifetime;

public class AsteroidScript : MonoBehaviour
{
    public float initialLife = 100f;
    public float healthBarXScaleAtMax = 7.5f;
    public Vector3 healthBarOffset = new Vector3(0, 4, 0);
    public AudioClip explosion;
    public GameObject resources;

    private float life;
    public GameObject healthBarPrefab;
    private GameObject healthBar;

    public int asteroidType;

    // Use this for initialization
    void Start()
    {
        life = initialLife;
        healthBar = GameObject.Instantiate(healthBarPrefab);
        
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 position = gameObject.transform.position;


        //random velocity
        // rb.AddForce(new Vector2(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10,10)), ForceMode2D.Impulse);

        rb.AddForce(new Vector2(-position.x, -position.y).normalized*10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("collided!!!!");
        Impact();
    }

    public void Impact()

    {
        life -= 10;
        ScoreManager.score += 1;
        UpdateHealthBar(true);
        if (life < 0)
        {
            
            AudioSource.PlayClipAtPoint(explosion,transform.position);
            Destroy(healthBar);
            Destroy(gameObject);

            if (asteroidType == 2)
            {
                Instantiate(resources, transform.position,transform.rotation);
            }

        }
    }


    void UpdateHealthBar(bool changed=false)
    {
        healthBar.transform.position = transform.position + healthBarOffset;
        if (changed)
        {
            float percent = life / initialLife;
            healthBar.transform.localScale = new Vector3(healthBarXScaleAtMax * percent, 1, 1);
            healthBar.GetComponent<SpriteRenderer>().material.color = Utils.GetHealthColor(life, initialLife);
        }
        
    }
}
