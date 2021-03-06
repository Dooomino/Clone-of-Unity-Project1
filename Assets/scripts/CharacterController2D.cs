﻿using UnityEngine;

public class CharacterController2D : MonoBehaviour {
	[Header("General")]
	public float movementSpeed = 10.0f;
	public float smoothness = 0.05f;
	private Animator animator;
	private Rigidbody2D rb;
	private float speed;
	private Vector3 veclocity = Vector3.zero;
	private bool isFacingRight = true;
	[SerializeField] private LayerMask interactiveLayer;
	[SerializeField] private LayerMask enemyAttackLayer;
	[Header("Character Stats")]
	public float health = 100;
	public float mana = 100;
	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	//Update the animantion variables so that the animations can change
	private void Update(){
		//animator.SetFloat("Speed", speed);
		//animator.SetBool("isJumping", !isGrounded);
	}
	// Update is called once per frame
	private void FixedUpdate() {
		//Go through each collider that the player can stand on and check if the player is standing on it

		//Go through each interactable object that the player is touching and execute the function that corresponds to that
		//interactable object
		Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, 1.0f, interactiveLayer);
		foreach(Collider2D collider in colliders){
			if(collider.gameObject != gameObject){
				Interactable interact = collider.GetComponent<Interactable>();
				interact.OnCollision(this);
			}
		}
	}

	public void Move(float move, float verticalMove, bool jump){
		

		//Move the player horizontally if the player is on the ground or is allowed to move in the air
		Vector3 targetVelocity = new Vector2(move * movementSpeed, verticalMove * movementSpeed);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref veclocity, smoothness);
		speed = rb.velocity.magnitude;

		//Flip the character if it isn't facing the correct direction
		if(move < 0.0 && isFacingRight){
			Flip();
		}else if(move > 0.0 && !isFacingRight){
			Flip();
		}
	}

	private void Flip(){
		isFacingRight = !isFacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void takeDamage(float damage){
		health -= damage;
		if(health <= 0){
			Destroy(this.gameObject);
		}
	}
}
