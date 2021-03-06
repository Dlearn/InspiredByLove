﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyController : MonoBehaviour {

	// Use this for initialization
	public AudioClip clip1;
	AudioSource audio;
	private float x,y;
	public float speed = 1;
	private int counter;
	private int polarity;
	void Start () {
		//x = Random.value;
		//y = Random.value;
		//x = -1;
		//y = -1;
		//polarity = -1;
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		audio = camera.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {


		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate (x, y, 0f);


		counter++;
		if (counter == 60) {
			//x = polarity * Random.value;
			//y = polarity * Random.value;
			//polarity = polarity * -1;
			//counter = 0;
		}

		//Vector2 movement = new Vector2 (x, y);
		//GetComponent<Rigidbody2D>().velocity = movement*speed;
		//GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, (-384+16), (384-16)), Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -128+16, 192-16));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("bullet"))
		{	
			audio.Stop ();
			audio.clip = clip1;
			audio.PlayOneShot (clip1, 0.1f);
			Destroy (other.gameObject);
		}
	}
}
