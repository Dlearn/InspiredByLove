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
    float[] spikeStartingTimes;

    void Start () {
        // Initializing positions & timings
        stakeClones = new GameObject[6];
        stakeStartingPositions = new Vector2[6];
        stakeEndingPositions = new Vector2[6];
        stakeStartingTimes = new float[6];
        curseStartingPositions = new Vector2[9];
        curseEndingPositions = new Vector2[9];
        spikeClones = new GameObject[6];
        spikeStartingPositions = new Vector2[6];
        spikeEndingPositions = new Vector2[6];
        spikeStartingTimes = new float[6];

        stakeStartingPositions[0] = new Vector2(Random.Range(-256f, 128f), 640f);
		stakeStartingPositions[1] = new Vector2(Random.Range(256f, -128f), 640f);
		stakeStartingPositions[2] = new Vector2(Random.Range(256f, 384f), 640f);
		stakeStartingPositions[3] = new Vector2(Random.Range(-256f, -384f), 640f);
		stakeStartingPositions[4] = new Vector2(Random.Range(512f, 512f), 640f);
		stakeStartingPositions[5] = new Vector2(Random.Range(-512f, -512f), 640f);

		stakeEndingPositions[0] = new Vector2(Random.Range(-512f, -256f),-512f);
		stakeEndingPositions[1] = new Vector2(Random.Range(512f, 256f),-512f);
		stakeEndingPositions[2] = new Vector2(Random.Range(-512f, -384f), -512f);
		stakeEndingPositions[3] = new Vector2(Random.Range(512f, -384f), -512f);
		stakeEndingPositions[4] = new Vector2(Random.Range(-512f, -256f), -512f);
		stakeEndingPositions[5] = new Vector2(Random.Range(512f, 256f) , -512f);

		for (int i = 0; i < stakeEndingPositions.Length; i++) {
			stakeEndingPositions [i].y = stakeEndingPositions [i].y + 768/4;
		}

        stakeStartingTimes[0] = 1f;
        stakeStartingTimes[1] = 5f;
        stakeStartingTimes[2] = 9f;
        stakeStartingTimes[3] = 13f;
        stakeStartingTimes[4] = 17f;
        stakeStartingTimes[5] = 21f;

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

		spikeStartingPositions[0] = new Vector2(Random.Range(-562f, -462f), 384f);
		spikeStartingPositions[1] = new Vector2(Random.Range(-562f, -462f), 384f);
		spikeStartingPositions[2] = new Vector2(Random.Range(512f, 512f) , Random.Range(50f,-50f));
		spikeStartingPositions[3] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f,-50f));
		spikeStartingPositions[4] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f,-100f));
		spikeStartingPositions[5] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));

		spikeEndingPositions[0] = new Vector2(Random.Range(-562f, -462f), -384f);
		spikeEndingPositions[1] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
		spikeEndingPositions[2] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
		spikeEndingPositions[3] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
		spikeEndingPositions[4] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
		spikeEndingPositions[5] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);

        spikeStartingTimes[0] = 1f;
        spikeStartingTimes[1] = 1f;
        spikeStartingTimes[2] = 1f;
        spikeStartingTimes[3] = 1f;
        spikeStartingTimes[4] = 1f;
        spikeStartingTimes[5] = 1f;

        for (int i = 0; i < stakeStartingPositions.Length; i++) {
            StartCoroutine(InstantiateStake(stakeStartingTimes[i], i));
        }
        for (int i = 0; i < spikeStartingPositions.Length; i++)
        {
            StartCoroutine(InstantiateSpike(spikeStartingTimes[i], i));
        }
    }
    IEnumerator InstantiateStake(float time, int i) {
        yield return new WaitForSeconds(time);
        stakeClones[i] = Instantiate(stake, stakeStartingPositions[i], transform.rotation);
        if ((stakeStartingPositions[i] - stakeEndingPositions[i]).x <= 0) {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(stakeStartingPositions[i] - stakeEndingPositions[i], Vector2.up)));
        }
        else {
            stakeClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(stakeStartingPositions[i] - stakeEndingPositions[i], Vector2.up)));
        }
    }
    IEnumerator InstantiateSpike(float time, int i) {
        yield return new WaitForSeconds(time);
        spikeClones[i] = Instantiate(spike, spikeStartingPositions[i], transform.rotation);
        if ((spikeEndingPositions[i] - spikeStartingPositions[i]).y > 0) {
            spikeClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(spikeEndingPositions[i] - spikeStartingPositions[i], Vector2.left)));
        }
        else {
            spikeClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(spikeEndingPositions[i] - spikeStartingPositions[i], Vector2.left)));
        }
    }

    // Update is called once per frame
    void Update () {
        // Moving stake
        for (int i=0; i<stakeStartingPositions.Length; i++) {
            if (stakeClones[i] != null) {
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, stakeEndingPositions[i], Time.deltaTime * 400);
            }
        }

        // Moving spike
        for (int i = 0; i < spikeStartingPositions.Length; i++)
        {
            if (spikeClones[i] != null)
            {
                spikeClones[i].transform.position = Vector2.MoveTowards(spikeClones[i].transform.position, spikeEndingPositions[i], Time.deltaTime * 400);
            }
        }
    }
}
