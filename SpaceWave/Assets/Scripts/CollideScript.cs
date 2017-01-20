using System;
using UnityEngine;
using System.Collections;

public class CollideScript : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("OUCH!");
    }
}
