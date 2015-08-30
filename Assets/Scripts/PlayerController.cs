﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 4;
	public static PlayerController instance;
	public GameObject[] inventory;
	public GameObject[] upgrades;
	public int ammo = 0;

	private int counter = 0;
	private Rigidbody2D rb2d;
	private Animator animator;
	private MeleeAttacker meleeAttacker;
	private float playerRadius;

	// Use this for initialization
	void Start () {
		this.rb2d = this.GetComponent<Rigidbody2D> ();
		this.animator = this.GetComponent<Animator> ();
		this.meleeAttacker = this.GetComponent<MeleeAttacker> ();
		CircleCollider2D myCollider = transform.GetComponent <CircleCollider2D>();
		this.playerRadius = myCollider.radius;
	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Vector2 playerSpeed = new Vector2 (horizontal, vertical);
		float magnitude = playerSpeed.magnitude;
		if(magnitude == 0){
			magnitude = 1;
		}



		this.rb2d.velocity = this.speed * (playerSpeed/magnitude);

		if (horizontal > 0) {
			this.animator.SetInteger ("Direction", 3);
			this.animator.SetBool ("Idle", false);
		} else if (horizontal < 0) {
			this.animator.SetInteger ("Direction", 1);
			this.animator.SetBool ("Idle", false);
		} else if (vertical > 0) {
			this.animator.SetInteger ("Direction", 2);
			this.animator.SetBool ("Idle", false);
		} else if (vertical < 0) {
			this.animator.SetInteger ("Direction", 0);
			this.animator.SetBool ("Idle", false);
		} else {
			this.animator.SetBool ("Idle", true);
		}

		// combat controls

		// melee attack
		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("heeey");
			int direction = this.animator.GetInteger("Direction");

			if (direction == 0) {
				this.meleeAttacker.AttackSouth();
			} else if (direction == 1) {
				this.meleeAttacker.AttackWest();
			} else if (direction == 2) {
				this.meleeAttacker.AttackNorth();
			} else if (direction == 3) {
				this.meleeAttacker.AttackEast();
			}
		}

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

	public static bool checkAggro(float aggro, GameObject other){
		float distance = Vector2.Distance (instance.transform.position, other.transform.position);
		
		float enemyRadius = instance.transform.localScale.x * instance.playerRadius * aggro;
		if (distance <= enemyRadius) {
			return true;
		} else {
			return false;
		}
	}

	public Health Health {
		get {
			return this.GetComponent<Health> ();
		}
	}
}
