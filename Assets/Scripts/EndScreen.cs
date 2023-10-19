using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshPro highScore;

    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();

        var best = PlayerPrefs.GetInt("HighScore");
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", best);
        }
        highScore.text = best.ToString();
    }
}
