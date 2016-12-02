using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // public variables to be assigned in the editor
    public GameObject stake;

    // variables to be used in start and update
    GameObject[] stakeClones;
    Vector2[] startingPositions;
    Vector2[] endingPositions;
    float[] startingTimes;

    void Start () {
        // Initializing positions
        stakeClones = new GameObject[10];
        startingPositions = new Vector2[10];
        endingPositions = new Vector2[10];
        startingTimes = new float[10];

        startingPositions[0] = new Vector2(-256f, 640f);
        startingPositions[1] = new Vector2(-256f, 640f);
        startingPositions[2] = new Vector2(128f, 640f);
        startingPositions[3] = new Vector2(256f, 640f);
        startingPositions[4] = new Vector2(256f, 640f);
        startingPositions[5] = new Vector2(-128f, 640f);
        startingPositions[6] = new Vector2(256f, 640f);
        startingPositions[7] = new Vector2(384f, 640f);
        startingPositions[8] = new Vector2(-256f, 640f);
        startingPositions[9] = new Vector2(-384f, 640f);
        
        endingPositions[0] = new Vector2(-256f,-512f);
        endingPositions[1] = new Vector2(0f,-512f);
        endingPositions[2] = new Vector2(-200f, -512f);
        endingPositions[3] = new Vector2(256f, -512f);
        endingPositions[4] = new Vector2(0f, -512f);
        endingPositions[5] = new Vector2(200f, -512f);
        endingPositions[6] = new Vector2(-512f, -512f);
        endingPositions[7] = new Vector2(-384f, -512f);
        endingPositions[8] = new Vector2(512f, -512f);
        endingPositions[9] = new Vector2(256f, -512f);

        for (int i = 0; i < startingPositions.Length; i++) {
            StartCoroutine(ExecuteAfterTime(1f, i));
        }
    }
    IEnumerator ExecuteAfterTime(float time, int i)
    {
        yield return new WaitForSeconds(time);

        stakeClones[i] = Instantiate(stake, startingPositions[i], transform.rotation);
        if ((startingPositions[i] - endingPositions[i]).x <= 0)
        {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(startingPositions[i] - endingPositions[i], Vector2.up)));
        }
        else
        {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(startingPositions[i] - endingPositions[i], Vector2.up)));
        }
    }

    // Update is called once per frame
    void Update () {
        

        for (int i=0; i<startingPositions.Length; i++) { 
            if (stakeClones[i] != null) { 
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, endingPositions[i], Time.deltaTime * 1000);
            }
        }
    }
}
