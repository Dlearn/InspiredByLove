using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // public variables to be assigned in the editor
    public GameObject stake;
    public GameObject curse;
    public GameObject spike;

    // variables to be used in start and update
    GameObject[] stakeClones;
    GameObject[] curseClones;
    GameObject[] spikeClones;
    Vector2[] stakeStartingPositions;
    Vector2[] stakeEndingPositions;
    float[] stakeStartingTimes;
    Vector2[] curseStartingPositions;
    Vector2[] curseEndingPositions;
    Vector2[] spikeStartingPositions;
    Vector2[] spikeEndingPositions;

    void Start () {
        // Initializing positions & timings
        stakeClones = new GameObject[10];
        stakeStartingPositions = new Vector2[10];
        stakeEndingPositions = new Vector2[10];
        //stakeStartingTimes = new float[10];
        curseStartingPositions = new Vector2[9];
        curseEndingPositions = new Vector2[9];
        spikeStartingPositions = new Vector2[9];
        spikeEndingPositions = new Vector2[9];

        stakeStartingPositions[0] = new Vector2(-256f, 640f);
        stakeStartingPositions[1] = new Vector2(-256f, 640f);
        stakeStartingPositions[2] = new Vector2(128f, 640f);
        stakeStartingPositions[3] = new Vector2(256f, 640f);
        stakeStartingPositions[4] = new Vector2(256f, 640f);
        stakeStartingPositions[5] = new Vector2(-128f, 640f);
        stakeStartingPositions[6] = new Vector2(256f, 640f);
        stakeStartingPositions[7] = new Vector2(384f, 640f);
        stakeStartingPositions[8] = new Vector2(-256f, 640f);
        stakeStartingPositions[9] = new Vector2(-384f, 640f);
        
        stakeEndingPositions[0] = new Vector2(-256f,-512f);
        stakeEndingPositions[1] = new Vector2(0f,-512f);
        stakeEndingPositions[2] = new Vector2(-200f, -512f);
        stakeEndingPositions[3] = new Vector2(256f, -512f);
        stakeEndingPositions[4] = new Vector2(0f, -512f);
        stakeEndingPositions[5] = new Vector2(200f, -512f);
        stakeEndingPositions[6] = new Vector2(-512f, -512f);
        stakeEndingPositions[7] = new Vector2(-384f, -512f);
        stakeEndingPositions[8] = new Vector2(512f, -512f);
        stakeEndingPositions[9] = new Vector2(256f, -512f);

        /*
        curseStartingPositions[0] = new Vector2(512f,-384f);
        curseStartingPositions[1] = new Vector2(384f, -384f);
        curseStartingPositions[2] = new Vector2(256f, -384f);
        curseStartingPositions[3] = new Vector2(128f, -384f);
        curseStartingPositions[4] = new Vector2(0f, -384f);
        curseStartingPositions[5] = new Vector2(-128f, -384f);
        curseStartingPositions[6] = new Vector2(-256f, -384f);
        curseStartingPositions[7] = new Vector2(-384f, -384f);
        curseStartingPositions[8] = new Vector2(-512f, -384f);

        curseEndingPositions[0] = new Vector2(512f, -384f);
        curseEndingPositions[1] = new Vector2(384f, -384f);
        curseEndingPositions[2] = new Vector2(256f, -384f);
        curseEndingPositions[3] = new Vector2(128f, -384f);
        curseEndingPositions[4] = new Vector2(0f, -384f);
        curseEndingPositions[5] = new Vector2(-128f, -384f);
        curseEndingPositions[6] = new Vector2(-256f, -384f);
        curseEndingPositions[7] = new Vector2(-384f, -384f);
        curseEndingPositions[8] = new Vector2(-512f, -384f);
        */

        spikeStartingPositions[0] = new Vector2(512f, 384f);
        spikeStartingPositions[1] = new Vector2(562f, 384f);
        spikeStartingPositions[2] = new Vector2(462f, 384f);
        spikeStartingPositions[3] = new Vector2(-512f, 384f);
        spikeStartingPositions[4] = new Vector2(-562f, 384f);
        spikeStartingPositions[5] = new Vector2(-462f, 384f);
        spikeStartingPositions[6] = new Vector2(512f, 0f);
        spikeStartingPositions[7] = new Vector2(512f, 50f);
        spikeStartingPositions[8] = new Vector2(512f, -50f);

        spikeEndingPositions[0] = new Vector2(-1024f, -768);
        spikeEndingPositions[1] = new Vector2(-1024f, -768f);
        spikeEndingPositions[2] = new Vector2(-1024f, -768f);
        spikeEndingPositions[3] = new Vector2(1024f, -768f);
        spikeEndingPositions[4] = new Vector2(1024f, -768f);
        spikeEndingPositions[5] = new Vector2(1024f, -768f);
        spikeEndingPositions[6] = new Vector2(-1024f, 0f);
        spikeEndingPositions[7] = new Vector2(-256f, -50f);
        spikeEndingPositions[8] = new Vector2(-256f, 50f);

        for (int i = 0; i < stakeStartingPositions.Length; i++) {
            //StartCoroutine(InstantiateStake(1f, i));
        }
        for (int i = 0; i < spikeStartingPositions.Length; i++)
        {
            StartCoroutine(InstantiateSpike(1f, i));
        }
    }
    IEnumerator InstantiateStake(float time, int i)
    {
        yield return new WaitForSeconds(time);

        stakeClones[i] = Instantiate(stake, stakeStartingPositions[i], transform.rotation);
        if ((stakeStartingPositions[i] - stakeEndingPositions[i]).x <= 0)
        {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(stakeStartingPositions[i] - stakeEndingPositions[i], Vector2.up)));
        }
        else
        {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(stakeStartingPositions[i] - stakeEndingPositions[i], Vector2.up)));
        }
    }
    IEnumerator InstantiateSpike(float time, int i)
    {
        yield return new WaitForSeconds(time);

        spikeClones[i] = Instantiate(spike, spikeStartingPositions[i], transform.rotation);
        if ((spikeStartingPositions[i] - spikeEndingPositions[i]).x <= 0) {
            spikeClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(spikeStartingPositions[i] - spikeEndingPositions[i], Vector2.up)));
        }
        else {
            spikeClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(spikeStartingPositions[i] - spikeEndingPositions[i], Vector2.up)));
        }
    }

    // Update is called once per frame
    void Update () {
        // Moving stake
        for (int i=0; i<stakeStartingPositions.Length; i++) { 
            if (stakeClones[i] != null) { 
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, stakeEndingPositions[i], Time.deltaTime * 1000);
            }
        }

        // Moving spike
        for (int i = 0; i < spikeStartingPositions.Length; i++)
        {
            if (spikeClones[i] != null)
            {
                spikeClones[i].transform.position = Vector2.MoveTowards(spikeClones[i].transform.position, spikeEndingPositions[i], Time.deltaTime * 1000);
            }
        }
    }
}
