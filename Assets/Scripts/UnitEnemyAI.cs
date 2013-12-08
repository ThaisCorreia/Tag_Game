using UnityEngine;
using System.Collections;

public class UnitEnemyAI : Unit {
	
	public Transform target;
	protected float moveSpeed;
	protected float rotationSpeed = 2.0f;
	protected bool escape = false;
	NavMeshAgent agent;

	public override void Start () {
		
		moveSpeed = 4f;
		agent = GetComponent<NavMeshAgent>();
		
	}
	
	public override void Update () 
	{
		i++;
        Vector3 point;
        if(!tagged)
        {
            point = new Vector3(target.position.x, transform.position.y, target.position.z);
			transform.LookAt(point);
            escape = false;
        }
        else
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 tPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            point = 2.0f * position - tPosition;
			transform.LookAt(point);
        }
		
		agent.destination = point;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.transform == target && i >= 50){
			tagged = true;
			print("Enemy says: Catch me if you can!");
			i = 0;
		}
	}
}
