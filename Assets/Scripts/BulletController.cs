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
    float[] curseStartingTimes;
    Vector2[] spikeStartingPositions;
    Vector2[] spikeEndingPositions;
    float[] spikeStartingTimes;

    void Start() {
        // Initializing positions & timings
        stakeClones = new GameObject[8];
        stakeStartingPositions = new Vector2[8];
        stakeEndingPositions = new Vector2[8];
        stakeStartingTimes = new float[8];
        curseClones = new GameObject[30];
        curseStartingPositions = new Vector2[30];
        curseEndingPositions = new Vector2[30];
        curseStartingTimes = new float[30];
        spikeClones = new GameObject[30];
        spikeStartingPositions = new Vector2[30];
        spikeEndingPositions = new Vector2[30];
        spikeStartingTimes = new float[30];

        stakeStartingPositions[0] = new Vector2(Random.Range(-256f, 128f), 640f);
        stakeStartingPositions[1] = new Vector2(Random.Range(256f, -128f), 640f);
        stakeStartingPositions[2] = new Vector2(Random.Range(256f, 384f), 640f);
        stakeStartingPositions[3] = new Vector2(Random.Range(-256f, -384f), 640f);
        stakeStartingPositions[4] = new Vector2(Random.Range(512f, 512f), 640f);
        stakeStartingPositions[5] = new Vector2(Random.Range(-512f, -512f), 640f);
        stakeStartingPositions[6] = new Vector2(Random.Range(-256f, 128f), 640f);
        stakeStartingPositions[7] = new Vector2(Random.Range(256f, -128f), 640f);

        stakeEndingPositions[0] = new Vector2(Random.Range(-512f, -256f), -512f);
        stakeEndingPositions[1] = new Vector2(Random.Range(512f, 256f), -512f);
        stakeEndingPositions[2] = new Vector2(Random.Range(-512f, -384f), -512f);
        stakeEndingPositions[3] = new Vector2(Random.Range(512f, -384f), -512f);
        stakeEndingPositions[4] = new Vector2(Random.Range(-512f, -256f), -512f);
        stakeEndingPositions[5] = new Vector2(Random.Range(512f, 256f), -512f);
        stakeEndingPositions[6] = new Vector2(Random.Range(-512f, -256f), -512f);
        stakeEndingPositions[7] = new Vector2(Random.Range(512f, 256f), -512f);

        for (int i = 0; i < stakeEndingPositions.Length; i++) {
            stakeStartingPositions[i].y = stakeStartingPositions[i].y + 768 / 4;
            stakeEndingPositions[i].y = stakeEndingPositions[i].y + 768 / 4;
        }

        stakeStartingTimes[0] = 1f;
        stakeStartingTimes[1] = 5f;
        stakeStartingTimes[2] = 9f;
        stakeStartingTimes[3] = 13f;
        stakeStartingTimes[4] = 17f;
        stakeStartingTimes[5] = 21f;
        stakeStartingTimes[6] = 25f;
        stakeStartingTimes[7] = 29f;

        curseStartingPositions[0] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[1] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[2] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[3] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[4] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[5] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[6] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[7] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[8] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[9] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[10] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[11] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[12] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[13] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[14] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[15] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[16] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[17] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[18] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[19] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[20] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[21] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[22] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[23] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[24] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[25] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[26] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[27] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[28] = new Vector2(Random.Range(-384f, 384f), -384f);
        curseStartingPositions[29] = new Vector2(Random.Range(-384f, 384f), -384f);

        Vector2[] possibleCurseEndpoints = new Vector2[4];
        possibleCurseEndpoints[0] = new Vector2(-512f,0f);
        possibleCurseEndpoints[1] = new Vector2(-512f,384f);
        possibleCurseEndpoints[2] = new Vector2(512f,384f);
        possibleCurseEndpoints[3] = new Vector2(512f,0f);

        curseEndingPositions[0] = possibleCurseEndpoints[Random.Range(0,3)];
        curseEndingPositions[1] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[2] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[3] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[4] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[5] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[6] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[7] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[8] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[9] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[10] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[11] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[12] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[13] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[14] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[15] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[16] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[17] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[18] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[19] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[20] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[21] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[22] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[23] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[24] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[25] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[26] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[27] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[28] = possibleCurseEndpoints[Random.Range(0, 3)];
        curseEndingPositions[29] = possibleCurseEndpoints[Random.Range(0, 3)];

        curseStartingTimes[0] = 1f;
        curseStartingTimes[1] = 2f;
        curseStartingTimes[2] = 3f;
        curseStartingTimes[3] = 4f;
        curseStartingTimes[4] = 5f;
        curseStartingTimes[5] = 6f;
        curseStartingTimes[6] = 7f;
        curseStartingTimes[7] = 8f;
        curseStartingTimes[8] = 9f;
        curseStartingTimes[9] = 10f;
        curseStartingTimes[10] = 11f;
        curseStartingTimes[11] = 12f;
        curseStartingTimes[12] = 13f;
        curseStartingTimes[13] = 14f;
        curseStartingTimes[14] = 15f;
        curseStartingTimes[15] = 16f;
        curseStartingTimes[16] = 17f;
        curseStartingTimes[17] = 18f;
        curseStartingTimes[18] = 19f;
        curseStartingTimes[19] = 20f;
        curseStartingTimes[20] = 21f;
        curseStartingTimes[21] = 22f;
        curseStartingTimes[22] = 23f;
        curseStartingTimes[23] = 24f;
        curseStartingTimes[24] = 25f;
        curseStartingTimes[25] = 26f;
        curseStartingTimes[26] = 27f;
        curseStartingTimes[27] = 28f;
        curseStartingTimes[28] = 29f;
        curseStartingTimes[29] = 30f;

        spikeStartingPositions[0] = new Vector2(Random.Range(-562f, -462f), 384f);
		spikeStartingPositions[1] = new Vector2(Random.Range(-562f, -462f), 384f);
		spikeStartingPositions[2] = new Vector2(Random.Range(512f, 512f) , Random.Range(50f,-50f));
		spikeStartingPositions[3] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f,-50f));
		spikeStartingPositions[4] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f,-100f));
		spikeStartingPositions[5] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));
        spikeStartingPositions[6] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[7] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[8] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeStartingPositions[9] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeStartingPositions[10] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f, -100f));
        spikeStartingPositions[11] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));
        spikeStartingPositions[12] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[13] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[14] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeStartingPositions[15] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeStartingPositions[16] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f, -100f));
        spikeStartingPositions[17] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));
        spikeStartingPositions[18] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[19] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[20] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeStartingPositions[21] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeStartingPositions[22] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f, -100f));
        spikeStartingPositions[23] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));
        spikeStartingPositions[24] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[25] = new Vector2(Random.Range(-562f, -462f), 384f);
        spikeStartingPositions[26] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeStartingPositions[27] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeStartingPositions[28] = new Vector2(Random.Range(-512f, -512f), Random.Range(300f, -100f));
        spikeStartingPositions[29] = new Vector2(Random.Range(512f, 512f), Random.Range(300f, -100f));

        spikeEndingPositions[0] = new Vector2(Random.Range(-562f, -462f), -384f);
		spikeEndingPositions[1] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
		spikeEndingPositions[2] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
		spikeEndingPositions[3] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
		spikeEndingPositions[4] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
		spikeEndingPositions[5] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);
        spikeEndingPositions[6] = new Vector2(Random.Range(-562f, -462f), -384f);
        spikeEndingPositions[7] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
        spikeEndingPositions[8] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeEndingPositions[9] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeEndingPositions[10] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
        spikeEndingPositions[11] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);
        spikeEndingPositions[12] = new Vector2(Random.Range(-562f, -462f), -384f);
        spikeEndingPositions[13] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
        spikeEndingPositions[14] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeEndingPositions[15] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeEndingPositions[16] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
        spikeEndingPositions[17] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);
        spikeEndingPositions[18] = new Vector2(Random.Range(-562f, -462f), -384f);
        spikeEndingPositions[19] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
        spikeEndingPositions[20] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeEndingPositions[21] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeEndingPositions[22] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
        spikeEndingPositions[23] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);
        spikeEndingPositions[24] = new Vector2(Random.Range(-562f, -462f), -384f);
        spikeEndingPositions[25] = new Vector2(Random.Range(562f, 462f), Random.Range(-384f, 384f));
        spikeEndingPositions[26] = new Vector2(Random.Range(-512f, -512f), Random.Range(50f, -50f));
        spikeEndingPositions[27] = new Vector2(Random.Range(512f, 512f), Random.Range(50f, -50f));
        spikeEndingPositions[28] = new Vector2(spikeStartingPositions[4].x + 1024f, spikeStartingPositions[4].y);
        spikeEndingPositions[29] = new Vector2(spikeStartingPositions[5].x + 1024f, spikeStartingPositions[5].y);

        spikeStartingTimes[0] = 1f;
        spikeStartingTimes[1] = 2f;
        spikeStartingTimes[2] = 3f;
        spikeStartingTimes[3] = 4f;
        spikeStartingTimes[4] = 5f;
        spikeStartingTimes[5] = 6f;
        spikeStartingTimes[6] = 7f;
        spikeStartingTimes[7] = 8f;
        spikeStartingTimes[8] = 9f;
        spikeStartingTimes[9] = 10f;
        spikeStartingTimes[10] = 11f;
        spikeStartingTimes[11] = 12f;
        spikeStartingTimes[12] = 13f;
        spikeStartingTimes[13] = 14f;
        spikeStartingTimes[14] = 15f;
        spikeStartingTimes[15] = 16f;
        spikeStartingTimes[16] = 17f;
        spikeStartingTimes[17] = 18f;
        spikeStartingTimes[18] = 19f;
        spikeStartingTimes[19] = 20f;
        spikeStartingTimes[20] = 21f;
        spikeStartingTimes[21] = 22f;
        spikeStartingTimes[22] = 23f;
        spikeStartingTimes[23] = 24f;
        spikeStartingTimes[24] = 25f;
        spikeStartingTimes[25] = 26f;
        spikeStartingTimes[26] = 27f;
        spikeStartingTimes[27] = 28f;
        spikeStartingTimes[28] = 29f;
        spikeStartingTimes[29] = 30f;

		for (int i = 0; i < stakeStartingPositions.Length; i++) {
			Debug.Log (spikeEndingPositions [i]);
		}

        for (int i = 0; i < stakeStartingPositions.Length; i++) {
			int choice = Random.Range (1, 20);
			int index;
			if (1 <= choice  && choice <= 2) {
				index = 0;
			} else if (3 <= choice && choice <= 4) {
				index = 1;
			} else if (5 <= choice && choice <= 7) {
				index = 2;
			} else if (8 <= choice && choice <= 10) {
				index = 3;
			} else if (11 <= choice && choice <= 15) {
				index = 4;
			} else {
				index = 5;
			}
            StartCoroutine(InstantiateStake(stakeStartingTimes[i], index));
        }
        for (int i = 0; i < curseStartingPositions.Length; i++) {
            StartCoroutine(InstantiateCurse(curseStartingTimes[i], i));
        }
        for (int i = 0; i < spikeStartingPositions.Length; i++) {
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
    IEnumerator InstantiateCurse(float time, int i)
    {
        yield return new WaitForSeconds(time);
        curseClones[i] = Instantiate(curse, curseStartingPositions[i], transform.rotation);
        if ((curseStartingPositions[i] - curseEndingPositions[i]).x <= 0)
        {
            curseClones[i].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(curseStartingPositions[i] - curseEndingPositions[i], Vector2.left)));
        }
        else
        {
            curseClones[i].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(curseStartingPositions[i] - curseEndingPositions[i], Vector2.right)));
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
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, stakeEndingPositions[i], Time.deltaTime * 300);
            }
        }

        // Moving curse
        for (int i = 0; i < curseStartingPositions.Length; i++)
        {
            if (curseClones[i] != null)
            {
                curseClones[i].transform.position = Vector2.MoveTowards(curseClones[i].transform.position, curseEndingPositions[i], Time.deltaTime * 300);
            }
        }

        // Moving spike
        for (int i = 0; i < spikeStartingPositions.Length; i++)
        {
            if (spikeClones[i] != null) {
                spikeClones[i].transform.position = Vector2.MoveTowards(spikeClones[i].transform.position, spikeEndingPositions[i], Time.deltaTime * 300);
            }
        }

		for (int i = 0; i < stakeEndingPositions.Length; i++) {
			if (stakeClones [i] != null) {
				Vector2 pos = stakeClones [i].transform.position;
				if (pos == stakeEndingPositions [i]) {
					stakeClones [i].tag = "bulletStationary";
				}
			}
		}
    }
}
