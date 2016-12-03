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



    // Use this for initialization
    void Start()
    {
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



    }

    // Update is called once per frame
    void Update()
    {

        if (player.flag)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        
        gameOver = true;

        GameObject background = GameObject.FindGameObjectWithTag("Background");
        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        sr.color = Color.black;
        // GetComponent<SpriteRenderer>.color = Color.black;

    }
}