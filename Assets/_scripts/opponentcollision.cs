using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentcollision : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("COLLISION");
		if (col.gameObject.tag == "opponent") {
			Debug.Log ("COLLISION2");
			Destroy (gameObject);
		}
	}

}
