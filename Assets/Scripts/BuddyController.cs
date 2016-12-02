﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyController : MonoBehaviour {

	// Use this for initialization
	private float x,y;
	public float speed;
	private int counter;
	void Start () {
		//x = Random.value;
		//y = Random.value;
		x = -1;
		y = -1;
		
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 60) {
			x = Random.value;
			y = Random.value;
			counter = 0;
		}

		Vector2 movement = new Vector2 (x, y);
		GetComponent<Rigidbody2D>().velocity = movement*speed;
		GetComponent<Rigidbody2D>().position = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, (-384+16), (384-16)), Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, -128+16, 192-16));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("bullet"))
		{
			Destroy (other.gameObject);
		}
	}
}
