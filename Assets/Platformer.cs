using UnityEngine;
using System.Collections;

public class Platformer : MonoBehaviour {
	RaycastHit rayHit;
	Ray downRay;
	
	public bool bumped = false, exitedTrigger;
	float timeOfBump;
	
	//Vector3 bumpPos, slideDestination;
	
	
	
	void Start () {}
		
	
	bool CheckOnGround() {
		downRay = new Ray( transform.position, -transform.up );
		if ( Physics.Raycast(downRay, out rayHit, 0.5f ) ) return true;
		else return false;		
	}
	

	
	
	void Update () {
		
		//set drag
		if (bumped) rigidbody.drag = 10;
		else rigidbody.drag = 5;
		
		
		
		if (bumped) {
			if( rigidbody.velocity == Vector3.zero && exitedTrigger ) {
				bumped = false;
				exitedTrigger = false;
			}
			/*
			//if ( Time.time - timeOfBump > howLongToBump )
			if ( rigidbody.velocity == Vector3.zero ) bumped = false;
			
			//stop sliding when 1f away
			//float slideDistance = Mathf.Abs( Vector3.Magnitude( bumpPos - transform.position ) );
			//if ( slideDistance > 2f ) {
				//bumped = false;
				//rigidbody.velocity = Vector3.zero;
			//}
			
			//slide
			//else {
				//Vector3 slideDirection = ( slideDestination - transform.position )* 200;
				//rigidbody.AddForce ( slideDirection );
			//}
		*/
		}
		
		
		
		if ( !bumped && CheckOnGround () ) {
			//move
			float speed = Input.GetAxis ("Vertical") * 20;;
			float rotation = Input.GetAxisRaw ("Horizontal") * 2;
			rigidbody.AddForce ( transform.forward * speed );
			transform.Rotate ( 0, rotation, 0 );
			
			//jump
			if ( Input.GetKeyDown( "space" ) ) {
				rigidbody.AddForce ( 0, 400, 0 );	
			}
		}
		
		
		
	}
	
	void OnTriggerEnter() {
		/*
		//bumpPos = transform.position;
		//slideDestination = transform.position - transform.forward*2;
		//rigidbody.AddForce( -transform.forward );
		//rigidbody.drag = 20;
		*/
		rigidbody.velocity = Vector3.zero;
		bumped = true;
	}
	void OnTriggerExit() {
		exitedTrigger = true;
	}
	
}
