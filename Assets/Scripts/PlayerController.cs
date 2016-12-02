using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	public float speed;
	private float actualDistance;
	public float distance = 1.0f;
	public bool useInitialCameraDistance = false;
	void Start () {

		if (useInitialCameraDistance) {
			Vector3 toObjectVector = transform.position - Camera.main.transform.position;
			Vector3 linearDistanceVector = Vector3.Project (toObjectVector, Camera.main.transform.forward);
			actualDistance = linearDistanceVector.magnitude;
		} else {
			actualDistance = distance;
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


		Vector3 mousePos = Input.mousePosition;
		mousePos.z = actualDistance;
		//transform.position = Camera.main.ScreenToWorldPoint (mousePos);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);

		Vector2 movement = new Vector2(mousePos.x, mousePos.y);

        GetComponent<Rigidbody2D>().velocity = movement*speed;
		GetComponent<Rigidbody2D>().position = new Vector2(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y);
		//GetComponent<Rigidbody2D>().position = new Vector2(mousePos.x, mousePos.y);
		//transform.position = Vector2.Lerp(transform.position, mousePos, speed);
    }
}