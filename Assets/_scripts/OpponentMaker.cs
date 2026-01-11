using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMaker : MonoBehaviour {
	public Rigidbody opponentPrefab;
	public float range;
	public float waitforsec;
	public int opponentlimit;
	private Rigidbody opponent; 
	private Vector3 newposition;
	private bool findval;
	private int clonecount;

	// Use this for initialization
	void Start () {
		opponent = GetComponent<Rigidbody> ();
		newposition = opponent.transform.position;
		StartCoroutine(Waiting());
		clonecount = 1;
	}

	// Update is called once per frame
	void Update () {
	}

	IEnumerator Waiting()
	{
		while (clonecount<=opponentlimit) {
			//float randval = Random.value * range; //delete
			//Debug.Log(randval);
			newposition = opponent.transform.position;
			if (clonecount == 3) { //BAD WAY TO SOLVE THIS PROBLEM
				clonecount++;
			}
			newposition += new Vector3 (clonecount*range,0,0); 
		
			yield return new WaitForSeconds (waitforsec);
			Instantiate (opponentPrefab, newposition, Quaternion.Euler(0,180,0));
			clonecount++;
		}
	}

}
