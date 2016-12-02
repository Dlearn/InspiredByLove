using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyController : MonoBehaviour {

	// Use this for initialization
	private float x,y;
	public float speed;
	private int counter;
	void Start () {
		x = Random.value;
		y = Random.value;
		
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
		GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y);
	}
}
