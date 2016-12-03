using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // public variables to be assigned in the editor
    public GameObject stake;
    public GameObject curse;
    public GameObject spike;

    // Stakes
    GameObject[] stakeClones;
    int[] stakeDestinations;
    int stakeCounter = 0;

    // Spikes
    GameObject[] spikeClones;
    int[] spikeDestinations;
    int spikeCounter = 0;

    // Game Dimensions
    float HEIGHT = 768;
    float WIDTH = 1024;

    Vector2[] positions;

    void Start() {
        stakeCounter = 0;
        stakeClones = new GameObject[999];
        stakeDestinations = new int[999];

        spikeCounter = 0;
        spikeClones = new GameObject[999];
        spikeDestinations = new int[999];

        // Initializing positions & timings
        /* Grid to allocate start and ending positions
         *     0 1 2 3 4 5 6 7 8 9 10
         *     x x x x x x x x x x x 
         * 11  x                   x 12
         * 13  x                   x ...
         * 15  x                   x
         * 17  x                   x
         * 19  x                   x
         * 21  x                   x
         * 23  x                   x
         * 25  x                   x
         * 27  x                   x
         *     x x x x x x x x x x x
         *     29  31  33  35  37  39
         * */
        positions = new Vector2[40];
        for (int i = 0; i < 11; i++) {
            // Top row positions
            positions[i] = new Vector2((i - 1) * WIDTH/8 - WIDTH/2, HEIGHT * 5/8);
            // Bottom row positions
            positions[i + 29] = new Vector2((i - 1) * WIDTH / 8 - WIDTH / 2, -HEIGHT * 5/8);
        }
        for (int i = 0; i < 9; i++) {
            // Left column positions
            positions[2 * i + 11] = new Vector2(-WIDTH * 5 / 8, i * HEIGHT / 8 - HEIGHT / 2);
            // Right column positions
            positions[2 * i + 12] = new Vector2(WIDTH * 5 / 8, i * HEIGHT / 8 - HEIGHT / 2);
        }

        // Make a cascade of northwestern stakes
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(InstantiateStake(i, i + 6, i + 32));
        }

        // Make a cascade of eastern stakes
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(2*i + 17);
            Debug.Log(positions[2*i + 17]);
            
            StartCoroutine(InstantiateSpike(i+6, 2*i + 17, 2*i + 18));
        }
    }
    IEnumerator InstantiateStake(float startTime, int startPoint, int endPoint) {
        yield return new WaitForSeconds(startTime);
        
        // Bulletpool code
        stakeClones[stakeCounter] = Instantiate(stake, positions[startPoint], transform.rotation);
        stakeDestinations[stakeCounter] = endPoint;
        
        if ((positions[startPoint] - positions[endPoint]).x <= 0) {
            stakeClones[stakeCounter].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(positions[startPoint] - positions[endPoint], Vector2.up)));
        }
        else {
            stakeClones[stakeCounter].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(positions[startPoint] - positions[endPoint], Vector2.up)));
        }
        stakeCounter++;
    }

    IEnumerator InstantiateSpike(float startTime, int startPoint, int endPoint)
    {
        yield return new WaitForSeconds(startTime);

        // Bulletpool code
        spikeClones[spikeCounter] = Instantiate(spike, positions[startPoint], transform.rotation);
        spikeDestinations[spikeCounter] = endPoint;

        if ((positions[startPoint] - positions[endPoint]).x <= 0)
        {
            spikeClones[spikeCounter].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(positions[startPoint] - positions[endPoint], Vector2.up)));
        }
        else
        {
            spikeClones[spikeCounter].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(positions[startPoint] - positions[endPoint], Vector2.up)));
        }
        spikeCounter++;
    }

    // Update is called once per frame
    void Update () {
        // Moving stake
        for (int i = 0; i < stakeCounter; i++)
        {
            if (stakeClones[i] != null)
            {
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, positions[stakeDestinations[i]], Time.deltaTime * 300);
            }
        }
        for (int i = 0; i < spikeCounter; i++)
        {
            if (spikeClones[i] != null)
            {
                spikeClones[i].transform.position = Vector2.MoveTowards(spikeClones[i].transform.position, positions[spikeDestinations[i]], Time.deltaTime * 300);
            }
        }

        // Moving curse
        /*
        for (int i = 0; i < cursepositions.Length; i++)
        {

        }

        // Moving spike
        for (int i = 0; i < spikepositions.Length; i++)
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
        */
    }
    }
