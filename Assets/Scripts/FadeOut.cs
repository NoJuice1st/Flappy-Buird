using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private SpriteRenderer render;
    private float timeElapsed;
    public float wait = 0;
    private bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopped)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > wait)
            {
                var color = render.color;
                color.a -= Time.deltaTime;

                render.color = color;
                
                if(color.a <= 0f)
                {
                    stopped = true;
                }
            }
        }
    }
}
