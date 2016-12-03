using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Use this for initialization
    public float speed;
    public bool flag = false;

    private float actualDistance;
    public float distance = 0f;
    public bool useInitialCameraDistance = false;
    private float finalX, finalY;

    private float radius = 200;
    public float testing;
    public GameObject buddy;

    void Start()
    {

        if (useInitialCameraDistance)
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            actualDistance = linearDistanceVector.magnitude;
        }
        else
        {
            actualDistance = distance;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 buddyPos = buddy.transform.position;
        Vector3 mousePos = Input.mousePosition;
        Vector3 finalV;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        Vector3 temp = mousePos - buddyPos;
        float dist = (temp).magnitude;
        finalV = mousePos;
		//Debug.Log (mousePos);
		finalV.x = Mathf.Clamp (finalV.x, -512+32, 512-32);
		finalV.y = Mathf.Clamp (finalV.y, -384+32, 384-32);
		if (dist >= radius)
        {
            // distance between the mouse ptr and buddy exceeds radius
            // set the new ptr to within radius
			finalV.x = Mathf.Clamp((buddyPos.x + (temp.x / dist) * radius), -512+32, 512-32);
			finalV.y = Mathf.Clamp((buddyPos.y + (temp.y / dist) * radius), -384+32, 384-32);
        }

        transform.position = finalV;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            flag = true;
            other.gameObject.SetActive(false);
        }

		if (other.gameObject.CompareTag ("bulletStationary")) {
			flag = true;
			Destroy (other.gameObject);
		}
    }
}