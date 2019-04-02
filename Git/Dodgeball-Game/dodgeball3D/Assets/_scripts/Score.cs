using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	public float vol; 
	public AudioClip deathSound;
	private AudioSource source;
	private bool played;
	private Text score;
	// Use this for initialization
	void Start()
	{
		source = GetComponent<AudioSource>();
		score = GetComponent<Text>();
		played = false; 
	}

	// Update is called once per frame
	void Update()
	{
		if (CameraController.hitCount > 0) {
			score.text = "Lives Left: " + CameraController.hitCount.ToString ();
		} else {	
			
			if (!played) {
					source.PlayOneShot (deathSound, vol);
					played = true;
			} 
			else if (played) {
				score.text = "Game Over";
				PlayerPrefs.SetFloat ("timeSurvived", CameraController.timeSurvived);
				Debug.Log (CameraController.timeSurvived);
				SceneManager.LoadScene (2);
			}
		}
	}

}
