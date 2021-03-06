﻿using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour {
	public float runSpeed = 40.0f;
	private CharacterController2D controller;
	private PlayerActions actionController;
	private Animator animator;
	private float horizontalMove = 0.0f;
	private float verticalMove = 0.0f;
	private bool jumping = false;
	private HashSet<string> actions;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController2D>();
		actionController = GetComponent<PlayerActions>();
		animator = GetComponent<Animator>();
		actions = new HashSet<string>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the player gives input through the keyboard, set the movement speeds and jumping
		actions.Clear();
		if(!animator.GetBool("isDead")){ //Only move if the player isn't dead
			horizontalMove = Input.GetAxis("Horizontal") * runSpeed; 
			verticalMove = Input.GetAxis("Vertical") * runSpeed;
		}else{
			horizontalMove = 0; 
			verticalMove = 	0;
		}
		
		if(verticalMove != 0 || horizontalMove != 0){
			animator.SetFloat("speed",1);
		}else{
			animator.SetFloat("speed",0);
		}

		if(Input.GetButtonDown("Fire1")){
			actions.Add("1");
		}else if(Input.GetButtonDown("Jump")){
			actions.Add("5");
		}
	}
	void FixedUpdate(){
		//Actually perform the movements on the character
		
		controller.Move(horizontalMove * Time.fixedDeltaTime,verticalMove * Time.fixedDeltaTime, jumping);
		jumping = false;
		actionController.Action(actions);
		
	}
}
