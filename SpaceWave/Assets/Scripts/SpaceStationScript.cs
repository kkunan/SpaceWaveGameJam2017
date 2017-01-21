using UnityEngine;
using System.Collections;

public class SpaceStationScript : MonoBehaviour
{
	public float turningSpeed = 5.0f;

	private float targetAngle = 0.0f;

	// Use this for initialization
	void Start ()
	{	    
	}
	
	// Update is called once per frame
	// Do not adjust rigidbodies or colliders etc. in this method!
	void Update () {
		 HandleMouseInput();
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
		targetAngle = angle + turningSpeed*Time.deltaTime*turn;
	}

	void HandleMouseInput()
	{
		// Get the mouse pointer and turn it into a world vector (ie. an ingame vector)
		Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePoint.z = 0;
		// Get target angle to mouse pointer
		targetAngle = Mathf.Atan2(transform.position.y - mousePoint.y, transform.position.x - mousePoint.x) + Mathf.PI/2f;
	}

	// FixedUpdate is called once per physics tick
	// Do ALL physics based calls inside THIS method!!
	void FixedUpdate()
	{
		//float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
		//float maxSpeed = turningSpeed*Time.deltaTime;
		//float delta = Mathf.Clamp(targetAngle - angle, -maxSpeed, maxSpeed);
		// TODO: gracefully elegant sliding towards target
		transform.rotation =Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, (targetAngle) * Mathf.Rad2Deg),turningSpeed*Time.deltaTime);

	}
}
