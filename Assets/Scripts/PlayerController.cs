using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
	public float jumpForce;

    public CharacterController controller;
	public Vector3 moveDirection;
	public float gravityScale;

	public float ghostJumpTime;
	private float jumpableTimer;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded)
			jumpableTimer = 0f;
		else
			jumpableTimer += Time.deltaTime;

		float ytemp = moveDirection.y;
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= moveSpeed;
		moveDirection.y = ytemp;

		if(controller.isGrounded)
			moveDirection.y = 0f;

		if(jumpableTimer<ghostJumpTime){
			if (Input.GetButtonDown("Jump")) {
				moveDirection.y = jumpForce;
				jumpableTimer = ghostJumpTime;
			}
		}

		moveDirection.y += (Physics.gravity.y*gravityScale*Time.deltaTime);


		controller.Move(moveDirection*Time.deltaTime);
	}
}
