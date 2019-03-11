using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour {
	private BoxCollider player;
	public float speed; 
	public float suby;
	public float subx;
    public int ballSpeed;

	private Vector3 currentposition;
 
	// Use this for initialization
	void Start () {
        	System.Random rand = new System.Random();
		ballSpeed = 12;
		player = GameObject.FindWithTag("MainCamera").GetComponent<BoxCollider> ();
        currentposition = player.transform.position + new Vector3(rand.Next(-2,2),0,0);
	}
	
	// Update is called once per frame
	void Update () {
        float step = ballSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentposition, step);
		if (transform.position == currentposition){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter () {
		Destroy (gameObject); 
	}
}
