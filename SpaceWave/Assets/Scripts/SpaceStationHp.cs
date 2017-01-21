using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpaceStationHp : MonoBehaviour {
	public float lives;
	float currentlife;
	public Image livesValueImage;
	// Use this for initialization
	void Start () {
		currentlife = lives;
		Color currentColor = livesValueImage.color;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void UpdateLives(){
		

	}
	void OnCollisionEnter2D(Collision2D other){
		print ("collided");
		currentlife -= 10;
		float percent = currentlife / lives;
		livesValueImage.fillAmount = percent;
		Color currentColor = livesValueImage.color;
		if (percent > 0.65f) {
			livesValueImage.color = new Color (currentColor.r + 0.1f/0.35f, currentColor.g, 0,1);
		} else if (percent <= 0.65f && percent > 0.30f) {
			livesValueImage.color = new Color (1 , currentColor.g-0.1f/0.35f, 0,1);
		} else if(percent<-0.3f){
			livesValueImage.color = new Color (1, 0, 0,1);
		}

		//print (currentColor);


	}
}
