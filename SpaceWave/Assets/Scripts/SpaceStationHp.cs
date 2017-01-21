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
		Debug.Log ("collided");
		currentlife -= 10;
		float percent = currentlife / lives;
		livesValueImage.fillAmount = percent;
	    livesValueImage.color = Utils.GetHealthColor(currentlife, lives);
	}
}
