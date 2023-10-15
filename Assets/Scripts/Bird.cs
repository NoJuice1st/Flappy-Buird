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

    private Rigidbody2D rb;
    private string currentScene;
    private int playerScore;
    private TextMeshPro scoreText;
    private AudioSource audioS;

    #endregion

    void Start() // Game setup
    {
        //Set pipe Speed
        Pipe.speed = speed;

        //Get a random Bird
        int i = Random.Range(0, transform.childCount);
        
        transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;

        // Get Objects
        rb = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene().name;
        scoreText = GameObject.Find("PlayerScore").GetComponent<TextMeshPro>();
        audioS = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
    }

    // The bird dies!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    // Die function
    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;

        Invoke("ShowMenu", 1f);
        //SceneManager.LoadScene(currentScene);
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
        audioS.Play();
    }

    void Update()
    {
        // check when mouse is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        // Change rotation based on velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }
}
