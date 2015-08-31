﻿using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour {

	private 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D newOther) {
		Collider2D other = newOther.collider;
		if (other.tag == "Player") {
			PlayerController.instance.AddWeaponOrTool (this.gameObject.GetComponent<ItemController>().name);
		}
	}
}
