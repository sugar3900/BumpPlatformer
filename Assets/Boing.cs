using UnityEngine;
using System.Collections;

public class Boing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter() {
		audio.Play();
	}
	
}
