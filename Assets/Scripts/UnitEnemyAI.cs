using UnityEngine;
using System.Collections;

public class UnitEnemyAI : Unit {
	
	public Transform target;
	protected float moveSpeed = 4f;
	protected float rotationSpeed = 2.0f;
	protected bool escape = false;

	public override void Start () {
		
	}
	
	public override void Update () 
	{
		i++;
		Vector3 point;
		if(!tagged)
		{
			point = new Vector3(target.position.x, 0f, target.position.z);
			transform.LookAt(point);
			escape = false;
		}
		else
		{
			Vector3 position = new Vector3(transform.position.x, 0f, transform.position.z);
			Vector3 tPosition = new Vector3(target.position.x, 0f, target.position.z);
			point = 2.0f * position - tPosition;
    		transform.LookAt(point);
		}
		
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.transform == target && i >= 50){
			tagged = true;
			print("Enemy says: Catch me if you can!");
		}
	}
}
