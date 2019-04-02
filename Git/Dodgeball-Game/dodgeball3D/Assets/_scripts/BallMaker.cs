using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMaker : MonoBehaviour {
	public Rigidbody ballPrefab;
	public float waitforsec;
	private Rigidbody opponent; 
	private Vector3 opppos;

	// Use this for initialization
	void Start () {
		opponent = GetComponent<Rigidbody> ();
		opppos= opponent.transform.position;
		StartCoroutine(Waiting());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Waiting()
	{
		while (true) {
		yield return new WaitForSeconds (waitforsec);
           	System.Random rand = new System.Random();
            	int a = rand.Next(0, 5);
           	if (a == 4) {
                	Instantiate(powerupPrefab, opppos + new Vector3(0, 1), Quaternion.identity);
            	} else
            	{
                	Instantiate(ballPrefab, opppos + new Vector3(0, 1), Quaternion.identity);
            	}
            
        	}
	}

}
