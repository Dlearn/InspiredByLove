using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    // public variables to be assigned in the editor
    public GameObject stake;
    public GameObject spike;
    public GameObject chase;
    public GameObject player;

	// audio files
	public AudioClip impact;
	public AudioClip stackLanded;
	public AudioClip blocked;
	public AudioClip spikeSound;

	AudioSource audio;

    // Stakes
    GameObject[] stakeClones;
    int[] stakeDestinations;
    int stakeCounter = 0;

    // Spikes
    GameObject[] spikeClones;
    int[] spikeDestinations;
    int spikeCounter = 0;

    // Chase
    GameObject[] chaseClones;
    Vector2[] chaseDestinations;
    int chaseCounter = 0;

    // Game Dimensions
    float HEIGHT = 768;
    float WIDTH = 1024;

    Vector2[] positions;

    void Start() {
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		audio = camera.GetComponent<AudioSource> ();

        stakeCounter = 0;
        stakeClones = new GameObject[999];
        stakeDestinations = new int[999];

        spikeCounter = 0;
        spikeClones = new GameObject[999];
        spikeDestinations = new int[999];

        chaseCounter = 0;
        chaseClones = new GameObject[999];
        chaseDestinations = new Vector2[999];

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
        for (int i = 0; i < 11; i++)
        {
            // Top row positions
            positions[i] = new Vector2((i - 1) * WIDTH / 8 - WIDTH / 2, HEIGHT * 5 / 8);
            // Bottom row positions
            positions[i + 29] = new Vector2((i - 1) * WIDTH / 8 - WIDTH / 2, -HEIGHT * 5 / 8);
        }
        for (int i = 0; i < 9; i++)
        {
            // Left column positions
            positions[2 * i + 11] = new Vector2(-WIDTH * 5 / 8, (4 - i) * HEIGHT / 8);
            // Right column positions
            positions[2 * i + 12] = new Vector2(WIDTH * 5 / 8, (4 - i) * HEIGHT / 8);
        }

        /*
        // Make a cascade of southwestern stakes
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(InstantiateStake(3+i, i + 6, i + 32));
        }

        // Make a cascade of eastern spikes
        for (int i = 0; i < 5; i++) {
            StartCoroutine(InstantiateSpike(7+i, 2*i + 18, 2*i + 17));
        }
        */
        
    }

    private void Spiral(float startTime)
    {
        for (int i = 0; i < 11; i++)
        {
            StartCoroutine(InstantiateSpike(i / 2f + startTime, 39 - i, i));
        }
    }

    private void BoxSqueeze(float startTime)
    {
        StartCoroutine(InstantiateStake(startTime, 0, 30));
        StartCoroutine(InstantiateStake(startTime, 10, 38));
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(InstantiateStake(2 * i + startTime + 2, 2 * i + 11, 31 + i));
            StartCoroutine(InstantiateStake(2 * i + startTime + 2, 2 * i + 12, 37 - i));
        }
    }

    private void TopStab(float startTime)
    {
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(InstantiateSpike(2 + i + startTime, 2 * i + 12, 2 * i + 11));
            StartCoroutine(InstantiateSpike(2 + i + startTime, 2 * i + 11, 2 * i + 12));
        }
    }

    private void AdvancedBox(float startTime)
    {
            StartCoroutine(InstantiateStake(startTime, 14, 13));
            StartCoroutine(InstantiateStake(startTime, 17, 18));
            StartCoroutine(InstantiateStake(startTime, 22, 21));
            StartCoroutine(InstantiateStake(startTime, 25, 24));
            StartCoroutine(InstantiateStake(startTime + 2, 0, 39));
            StartCoroutine(InstantiateStake(startTime + 2, 39, 0));
            StartCoroutine(InstantiateStake(startTime + 2, 29, 10));
            StartCoroutine(InstantiateStake(startTime + 2, 10, 29));
            StartCoroutine(InstantiateStake(startTime + 4, 32, 31));
            StartCoroutine(InstantiateStake(startTime + 4, 36, 7));
            StartCoroutine(InstantiateStake(startTime + 6, 34, 5));
            StartCoroutine(InstantiateStake(startTime + 6, 5, 34));
            StartCoroutine(InstantiateStake(startTime + 8, 30, 1));
            StartCoroutine(InstantiateStake(startTime + 8, 33, 4));
            StartCoroutine(InstantiateStake(startTime + 8, 35, 6));
            StartCoroutine(InstantiateStake(startTime + 8, 38, 9));
    }

    private void LineOfChasers(float startTime) {
        for (int i = 0; i < 11; i++)
        {
            StartCoroutine(InstantiateChase(i / 2f + startTime, i));
        }
    }

    private void DoubleUp()
    {
        for (int i = 0; i < 5; i++)
        {

        }
    }

    IEnumerator InstantiateStake(float startTime, int startPoint, int endPoint) {
        yield return new WaitForSeconds(startTime);

        // Bulletpool code
        stakeClones[stakeCounter] = Instantiate(stake, positions[startPoint], transform.rotation);
        stakeDestinations[stakeCounter] = endPoint;
		//stakeClones [stakeCounter].transform.localScale += new Vector3 (0, 1, 0);
		audio.PlayOneShot (stackLanded, 0.5f);
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
		audio.PlayOneShot (spikeSound, 0.5f);

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

    IEnumerator InstantiateChase(float startTime, int startPoint)
    {
        yield return new WaitForSeconds(startTime);

        chaseClones[chaseCounter] = Instantiate(chase, positions[startPoint], transform.rotation);
        chaseDestinations[chaseCounter] = ((Vector2) player.transform.position - positions[startPoint]).normalized * 512f;

		audio.PlayOneShot (impact, 0.5f);
        if ((positions[startPoint] - chaseDestinations[chaseCounter]).x <= 0)
        {
            chaseClones[chaseCounter].transform.Rotate(new Vector3(0f, 0f, Vector2.Angle(positions[startPoint] - chaseDestinations[chaseCounter], Vector2.up)));
        }
        else
        {
            chaseClones[chaseCounter].transform.Rotate(new Vector3(0f, 0f, -Vector2.Angle(positions[startPoint] - chaseDestinations[chaseCounter], Vector2.up)));
        }
        chaseCounter++;
    }

    // Update is called once per frame
    void Update () {
        // Moving stake
        for (int i = 0; i < stakeCounter; i++)
        {
            if (stakeClones[i] != null)
            {
                stakeClones[i].transform.position = Vector2.MoveTowards(stakeClones[i].transform.position, positions[stakeDestinations[i]], Time.deltaTime * 200);
            }
        }
        // Moving spike
        for (int i = 0; i < spikeCounter; i++)
        {
            if (spikeClones[i] != null)
            {
                spikeClones[i].transform.position = Vector2.MoveTowards(spikeClones[i].transform.position, positions[spikeDestinations[i]], Time.deltaTime * 200);
            }
        }
        // Moving chaser
        for (int i = 0; i < chaseCounter; i++)
        {
            if (chaseClones[i] != null)
            {
                chaseClones[i].transform.position = Vector2.MoveTowards(chaseClones[i].transform.position, chaseDestinations[i], Time.deltaTime * 200);
            }
        }
        /*
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
