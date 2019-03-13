using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
	private Text score; 
	// Use this for initialization
	void Start () {
		score = GetComponent<Text>(); 
	}

	// Update is called once per frame
	void Update () {
        if (CameraController.hitCount > 0)
        {
            score.text = "Lives Left: " + CameraController.hitCount.ToString();
        } 
		else
        {
            score.text = "Game Over";
        	SceneManager.LoadScene (2);
        }
       
	}
}
