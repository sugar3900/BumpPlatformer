using UnityEngine;
using System.Collections;

public class WallBump : MonoBehaviour {
	Vector3 startPos;
	bool bumping = false;
	float distanceFromStart;
	

	void Start() {
		startPos = transform.position;
	}
	
	void Update() {
		
		distanceFromStart =  Mathf.Abs( Vector3.Magnitude( startPos - transform.position ) );
		rigidbody.velocity = Vector3.zero;
		
		
		if ( distanceFromStart != 0 ) {
			
			//bump block out
			if (bumping) {
				Vector3 bumpDirection = -transform.forward*1000;
				rigidbody.AddForce( bumpDirection );
				
				if ( distanceFromStart > 1f ) bumping = false;
			}
		
			//move block back to start
			else {
				Vector3 pullbackDirection = (startPos - transform.position) * 200;
				rigidbody.AddForce ( pullbackDirection );	
			}
		}
	
	}
	
	
	
	void OnTriggerEnter() {
		bumping = true;	
	}
}
