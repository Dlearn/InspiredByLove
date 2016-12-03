using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GlobalManager mng;
    private PlayerController player;

    public int score;
    public int spawnWait;
    public int startWait;
    public int waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;

    public System.String lovequote;
	public AudioClip endSound;

    // Use this for initialization
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        scoreText.text = "Score: " + score;
        GameObject mngObj = GameObject.FindGameObjectWithTag("GlobalManager");
        if (mngObj != null)
        {
            mng = mngObj.GetComponent<GlobalManager>();
        }

        if (mngObj == null)
        {
            Debug.Log("Cannot find 'GlobalManager' script");
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerController>();
        }

        if (playerObj == null)
        {
            Debug.Log("Cannot find 'PLayerController' script");
        }

        System.String[] lovequotes = new System.String[10];
        lovequotes[0] = "The best love is the kind that awakens the soul; that makes us reach for more, that plants the fire in our hearts and brings peace to our minds.";
        lovequotes[1] = "The couples that are meant to be, are the ones who go through everything that is meant to tear them apart, and come out even stronger.";
        lovequotes[2] = "The greatest happiness of life is the conviction that we are loved; loved for ourselves, or rather, loved in spite of ourselves.";
        lovequotes[3] = "All, everything that I understand, I only understand because I love.";
        lovequotes[4] = "It's a very dangerous state. You are inclined to recklessness and kind of tune out the rest of your life and everything that's been important to you. It's actually not all that pleasurable. I don't know who the hell wants to get in a situation where you can't bear an hour without somebody's company.";
        lovequotes[5] = "The best and most beautiful things in this world cannot be seen or even heard, but must be felt with the heart.";
        lovequotes[6] = "I saw that you were perfect, and so I loved you. Then I saw that you were not perfect and I loved you even more.";
        lovequotes[7] = "In order to be happy oneself it is necessary to make at least one other person happy.";
        lovequotes[8] = "The heart wants what it wants. There's no logic to these things. You meet someone and you fall in love and that's that.";
        lovequotes[9] = "There's no substitute for a great love who says, 'No matter what's wrong with you, you're welcome at this table.'";

        lovequote = lovequotes[Random.Range(0, 9)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            scoreText.text = "Score: " + score++;
        }
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (player.flag)
        {
            GameOver();
			player.flag = false;
        }
    }

    public void GameOver()
    {
        gameOverText.text = lovequote;

        gameOver = true;
        restartText.text = "Press 'Space' to restart the game";
        GameObject background = GameObject.FindGameObjectWithTag("Background");
        gameOverText.text = "Game Over!";
        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
		AudioSource audio = GetComponent<AudioSource>();
		audio.Stop ();
		audio.clip = endSound;
		audio.Play ();
        sr.color = Color.black;
        // GetComponent<SpriteRenderer>.color = Color.black;

    }
}
