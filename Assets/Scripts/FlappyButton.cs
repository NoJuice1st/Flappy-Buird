using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyButton : MonoBehaviour
{
    public string sceneName;
    public GameObject blackScreen;
    private SpriteRenderer render;
    private bool pressed;

    void Start()
    {
        if(blackScreen)render = blackScreen.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        transform.position += Vector3.down * 0.1f;
    }

    private void OnMouseUp()
    {
        transform.position += Vector3.up * 0.1f;
        if (blackScreen) pressed = true;
        else if (sceneName != "") SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if(pressed)
        {
            var color = render.color;
            color.a += Time.deltaTime * 2;

            render.color = color;

            if(color.a > 0.9f)
            {
                if (sceneName != "") SceneManager.LoadScene(sceneName);
            }
        }
    }
}
