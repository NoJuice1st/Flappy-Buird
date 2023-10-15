using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, transform.childCount);

        transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
    }
}
