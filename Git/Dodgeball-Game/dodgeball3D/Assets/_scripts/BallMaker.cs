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
			Instantiate (ballPrefab, opppos + new Vector3 (1, 2), Quaternion.Euler(0,180,0));
		}
	}

}
