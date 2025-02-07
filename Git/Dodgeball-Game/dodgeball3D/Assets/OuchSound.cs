﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchSound : MonoBehaviour {
	public float vol; 
	public AudioClip ouchSound;
    public AudioClip powerSound;
	private AudioSource source;

	// Use this for initialization

	void Start () {
		source = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ball")
		{
			source.PlayOneShot(ouchSound,vol);
		}
        if (other.tag == "powerup"){
            source.PlayOneShot(powerSound, vol);
        }


	}
}
