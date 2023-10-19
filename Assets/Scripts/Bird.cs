using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    #region gameValues

    public float jumpSpeed;
    public float rotatePower;
    public float speed;
    public GameObject endScreen;
    public GameObject flashEffect;

    private Rigidbody2D rb;
    private int playerScore;
    private TextMeshPro scoreText;
    private AudioSource scoreS;
    private AudioSource flapS;
    private AudioSource hitS;
    private AudioSource deathS;
    private bool sound = true;

    #endregion

    void Start() // Game setup
    {
        //Set pipe Speed
        Pipe.speed = speed;

        //Get a random Bird
        int i = Random.Range(0, transform.childCount);

        transform.GetChild(i).gameObject.SetActive(true);

        // Get Objects
        rb = GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("PlayerScore").GetComponent<TextMeshPro>();
        scoreS = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
        flapS = GameObject.Find("WingSound").GetComponent<AudioSource>();
        hitS = GameObject.Find("HitSound").GetComponent<AudioSource>();
        deathS = GameObject.Find("DeathSound").GetComponent<AudioSource>();
        Invoke("setGravityScale", 1.25f);
    }

    // The bird dies!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
        if(sound)
        {
            hitS.Play();
            deathS.Play();
            sound = false;
        }
    }
    // Die function
    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;

        Invoke("ShowMenu", 1f);
        flashEffect.SetActive(true);

        PlayerPrefs.SetInt("Score", playerScore);
    }

    void setGravityScale()
    {
        rb.gravityScale = 3;
    }

    void ShowMenu()
    {
        scoreText.gameObject.SetActive(false);
        endScreen.SetActive(true);
    }

    //get points if goes through pipes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        scoreS.Play();
    }

    void Update()
    {

        // check when mouse is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(rb.gravityScale != 3)
            {
                rb.gravityScale = 3;
            }
            flapS.Play();
            rb.velocity = Vector2.up * jumpSpeed;
        }

        // Change rotation based on velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }
}
