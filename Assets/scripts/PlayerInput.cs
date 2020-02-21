using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour {
	public float runSpeed = 40.0f;
	private CharacterController2D controller;
	private Animator animator;
	private float horizontalMove = 0.0f;
	private float verticalMove = 0.0f;
	private bool jumping = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the player gives input through the keyboard, set the movement speeds and jumping
		horizontalMove = Input.GetAxis("Horizontal") * runSpeed; 
		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
		verticalMove = Input.GetAxis("Vertical") * runSpeed;
	}
	void FixedUpdate(){
		//Actually perform the movements on the character
		controller.Move(horizontalMove * Time.fixedDeltaTime,verticalMove * Time.fixedDeltaTime, jumping);
		jumping = false;
	}
}
