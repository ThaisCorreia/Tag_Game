using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Unit : MonoBehaviour
{
	protected Vector3 move = Vector3.zero;
	protected Vector3 gravity = Vector3.zero;
	
	public float jumpSpeed = 1f;
	
	public static bool tagged = false;
	protected static int i = 100;
	
	public virtual void Start ()
	{
		
	}
	
	public virtual void Update ()
	{
		
	}
}
