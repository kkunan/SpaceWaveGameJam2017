using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpaceStationScript : MonoBehaviour
{
    public float turningSpeed = 5.0f;

    private float targetAngle = 0.0f;

    private float waveSpawnCounter = 0;

    public Boolean clicking;

    public float lives;
    float currentlife;

    public Image livesValueImage;

    public MainScript mainController;

    // Use this for initialization
    void Start()
    {
        currentlife = lives;
        mainController = GameObject.Find("GameManager").GetComponent<MainScript>();
    }

    // Update is called once per frame
    // Do not adjust rigidbodies or colliders etc. in this method!
    void Update()
    {
        HandleMouseInput();

        if (Input.GetMouseButton(0))
        {
            waveSpawnCounter -= Time.deltaTime;
            if (waveSpawnCounter < 0)
            {
                clicking = true;
                waveSpawnCounter = 0.1f;
            }

            else
            {
                clicking = false;
            }

        }

        else
        {
            clicking = false;
            waveSpawnCounter = 0;
        }

        //	HandleKeyboardInput();
    }

    void HandleKeyboardInput()
    {
        float turn = 0;
        if (Input.GetKey("a"))
        {
            turn += 1;
        }
        if (Input.GetKey("d"))
        {
            turn += -1;
        }


        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        targetAngle = angle + turningSpeed * Time.deltaTime * turn;
    }



    void HandleMouseInput()
    {

        // Get the mouse pointer and turn it into a world vector (ie. an ingame vector)
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0;
        // Get target angle to mouse pointer
        targetAngle = Mathf.Atan2(transform.position.y - mousePoint.y, transform.position.x - mousePoint.x) + Mathf.PI / 2f;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("collided!!!!");
        currentlife -= 10;

        float percent = currentlife / lives;
        livesValueImage.fillAmount = percent;

        Debug.Log(percent + " " + livesValueImage.fillAmount);

        Color currentColor = livesValueImage.color;

        if (percent > 0.65f)
        {
            livesValueImage.color = new Color(currentColor.r + 0.1f / 0.35f, currentColor.g, 0, 1);
        }
        else if (percent <= 0.65f && percent > 0.30f)
        {
            livesValueImage.color = new Color(1, currentColor.g - 0.1f / 0.35f, 0, 1);
        }
        else if (percent < -0.3f)
        {
            livesValueImage.color = new Color(1, 0, 0, 1);
        }
        if (currentlife <= 0)
        {
            //game over
            if (!mainController.gameOver)
            {
                // TODO: explode space station
                mainController.endGame();                
            }
        }
        //print (currentColor);


    }

    // FixedUpdate is called once per physics tick
    // Do ALL physics based calls inside THIS method!!

    
    void FixedUpdate()
    {
        //float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        //float maxSpeed = turningSpeed*Time.deltaTime;
        //float delta = Mathf.Clamp(targetAngle - angle, -maxSpeed, maxSpeed);
        // TODO: gracefully elegant sliding towards target
        transform.rotation = Quaternion.Euler(0, 0, (targetAngle) * Mathf.Rad2Deg);

    }
}