﻿using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public int amount = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D newOther) {
		Collider2D other = newOther.collider;
		print ("Is touching");
		if (other.tag == "Player") {
			PlayerController.instance.ammo += amount;
			Destroy (this.gameObject);
		}
		//PlayerController.instance.IncrementCounter ();
		//Destroy (this.gameObject);
	}
}
