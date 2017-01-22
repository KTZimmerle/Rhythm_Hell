using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

	public enum moveType{UseTransform, UsePhysics};
	public moveType moveTypes;
	public Transform[] pathPoints;
	public float speed;
	public int currentPath = 0;
	public float reachDistance = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch(moveTypes)
		{
			case moveType.UseTransform:
				UseTransform();
				break;

			case moveType.UsePhysics:
				UsePhysics();
				break;
		}
	}

	void OnDrawGizmos()
	{
		if (pathPoints == null)
		{
			return;
		}
		foreach (Transform pathPoint in pathPoints){
			if (pathPoint){
				Gizmos.DrawSphere(pathPoint.position, reachDistance);
			}
		}

	}

	void UseTransform(){
		Vector3 dir = pathPoints [currentPath].position - transform.position;
		Vector3 dirNorm = dir.normalized;
		transform.Translate(dirNorm * speed);
<<<<<<< HEAD

		//Making waves face movement direction -Craig
		//Feel free to remove this chunk and do this a better way if needed.  Sorry for mucking in your code, you were busy ~_~
		transform.rotation = Quaternion.LookRotation(dir);
		//End Craig's addition

=======
		//transform.LookAt (pathPoints[currentPath]);
>>>>>>> origin/master
		if (dir.magnitude <= reachDistance){
			currentPath++;
			if (currentPath >= pathPoints.Length){
				currentPath = 0;
			}
		}
	}

	void UsePhysics(){
		Vector3 dir = pathPoints[currentPath].position - transform.position;
		Vector3 dirNorm = dir.normalized;
		GetComponent<Rigidbody2D>().velocity = new Vector3(dirNorm.x * (speed * Time.fixedDeltaTime), GetComponent<Rigidbody2D>().velocity.y); 
	}
}



