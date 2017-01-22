using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Lifetime;

public class AsteroidScript : MonoBehaviour
{
    public float initialLife = 100f;
    public float healthBarXScaleAtMax = 100f;
    public Vector3 healthBarOffset = new Vector3(0, -20f, 0);
    public AudioClip explosion;
    public GameObject resources;

    private float life;
    public GameObject healthBarPrefab;
    private GameObject healthBar;

    public int asteroidType;

    public Sprite asteroid1;
    public Sprite asteroid2;

    public Sprite crack1_1;
    public Sprite crack2_1;
    public Sprite crack3_1;

    public Sprite crack1_2;
    public Sprite crack2_2;
    public Sprite crack3_2;

    // Use this for initialization
    void Start()
    {
        life = initialLife;
        healthBar = GameObject.Instantiate(healthBarPrefab);
        healthBar.SetActive(false);
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
        if(other.gameObject.tag == "Wave")
            ImpactFromWave();

        if (other.gameObject.tag == "Station")
        {
            Impact();
        }
    }

    public void ImpactFromWave()
    {
        Impact();
        ScoreManager.score += 1;
    }

    public void Impact()

    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(rb.position.x,rb.position.y).normalized*10);

        life -= 10;


        UpdateSprite();
        UpdateHealthBar(true);
        if (life < 0)
        {
            
            AudioSource.PlayClipAtPoint(explosion,transform.position);
            

            if (asteroidType == 2)
            {
               GameObject resource = (GameObject)Instantiate(resources, transform.position,transform.rotation);
                
                resource.GetComponent<Rigidbody2D>().AddForce(new Vector2(rb.velocity.x,rb.velocity.y).normalized*15);
            }

            Destroy(healthBar);
            Destroy(gameObject);
            

        }

    }

    void UpdateSprite()
    {
        SpriteRenderer gameObjectRenderer = gameObject.GetComponent<SpriteRenderer>();
        float percent = life/initialLife;

        if (percent >= 0.75f)
            return;
       
        if (percent < 0.75f && percent >= 0.5f)
        {
            //crack1
            if (asteroidType == 1)
            {
                gameObjectRenderer.sprite = crack1_1;
            }

            else
            {
                gameObjectRenderer.sprite = crack1_2;
            }
        }

        else if (percent < 0.5f && percent >= 0.25f)
        {
            //crack2
            if (asteroidType == 1)
            {
                gameObjectRenderer.sprite = crack2_1;
            }

            else
            {
                gameObjectRenderer.sprite = crack2_2;
            }
        }

        
        else
        {
            //crack3
            if (asteroidType == 1)
            {
                gameObjectRenderer.sprite = crack3_1;
            }

            else
            {
                gameObjectRenderer.sprite = crack3_2;
            }
        }

        Debug.Log(percent+" "+gameObjectRenderer.sprite);
    }


    void UpdateHealthBar(bool changed=false)
    {
        if (!healthBar.activeInHierarchy)
        {
            healthBar.SetActive(true);
        }
        healthBar.transform.position = gameObject.transform.position + healthBarOffset;
        if (changed)
        {
            float percent = life / initialLife;
            healthBar.transform.localScale = new Vector3(healthBarXScaleAtMax * percent, 15, 1);
        //    Debug.Log("percent "+percent+" hbmax "+healthBarXScaleAtMax);
            healthBar.GetComponent<SpriteRenderer>().material.color = Utils.GetHealthColor(life, initialLife);
        }
        
    }
}
