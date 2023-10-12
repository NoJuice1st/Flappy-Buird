using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    #region gameValues

    public float speed;
    public float rotatePower;

    private Rigidbody2D rb;
    private string currentScene;
    private int playerScore;
    private TextMeshPro TM;
    private AudioSource AS;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene().name;
        TM = GameObject.Find("PlayerScore").GetComponent<TextMeshPro>();
        AS = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
    }

    // restart game if dies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(currentScene);
    }

    //get points if goes through pipes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerScore++;
        TM.text = playerScore.ToString();
        AS.Play();
    }

    void Update()
    {   
        // check when mouse is clicked
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * speed;
        }

        // Change rotation based on velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }
}
