using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit {

	public CharacterController control;
	public Animator animator;
	
	public float moveSpeed = 3f;
	protected float rotationSpeed = 3f;
	
	protected bool jump;
	
	public override void Start ()
	{
		control = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		
		if(!control)
		{
			Debug.LogError("Unit.Start() " + name + " has no CharacterController!");
			enabled = false;
		}
		
		base.Start();
		
		animator.SetBool("Walking",false);
	}
	
	public override void Update () 
	{ 
		if (Input.GetKey("down") || Input.GetKey("up")) animator.SetBool("Walking",true);
		else animator.SetBool("Walking",false);
		
		transform.Rotate(0f,Input.GetAxis("Horizontal") * rotationSpeed, 0f);

		move = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

		move = transform.TransformDirection(move);
		
		if(Input.GetKey(KeyCode.Space) && control.isGrounded) jump = true;
		
		move *= moveSpeed;
		if(!control.isGrounded) gravity += Physics.gravity * Time.deltaTime;
		else
		{
			gravity = Vector3.zero;
			if(jump)
			{
				gravity.y = jumpSpeed;
				jump = false;
			}
		}
		move += gravity;
		control.Move(move * Time.deltaTime);
	}
	
	void OnControllerColliderHit(ControllerColliderHit collider)
	{
		if(collider.transform.name == "RobotEn" && tagged && i >= 50){
			tagged = false;
			print("RUN!!!");
			i = 0;
		}
	}
}
