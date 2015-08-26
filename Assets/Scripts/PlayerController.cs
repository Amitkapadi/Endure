﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 4;
	public static PlayerController instance;

	private int counter = 0;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		this.rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
//		this.transform.Translate (horizontal, vertical, 0);
		this.rb2d.velocity = this.speed * new Vector2 (horizontal, vertical);
	}
	//called before start
	void Awake () {
		if (PlayerController.instance == null) {
			PlayerController.instance = this;
		}

	}
	public void IncrementCounter () {
		this.counter ++;
		print (this.counter);
	}
}
