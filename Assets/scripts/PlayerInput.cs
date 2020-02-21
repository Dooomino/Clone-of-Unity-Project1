using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour {
	public float runSpeed = 40.0f;
	private CharacterController2D controller;
	private ActionController actionController;
	private Animator animator;
	private float horizontalMove = 0.0f;
	private float verticalMove = 0.0f;
	private bool jumping = false;
	private HashSet<string> actions;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController2D>();
		actionController = GetComponent<ActionController>();
		animator = GetComponent<Animator>();
		actions = new HashSet<string>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the player gives input through the keyboard, set the movement speeds and jumping
		actions.Clear();
		horizontalMove = Input.GetAxis("Horizontal") * runSpeed; 
		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
		verticalMove = Input.GetAxis("Vertical") * runSpeed;
		// if(Input.GetKeyDown("1")){
		if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("1")){
			actions.Add("1");
		}
	}
	void FixedUpdate(){
		//Actually perform the movements on the character
		controller.Move(horizontalMove * Time.fixedDeltaTime,verticalMove * Time.fixedDeltaTime, jumping);
		jumping = false;
		actionController.Action(actions);
	}
}
