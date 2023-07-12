using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    float timer = 0f;
    float scoreInterval = 1f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= scoreInterval)
        {
            timer = 0f;
            IncreaseScore();
        }
    }

    void IncreaseScore()
    {
        score += 10;
        Debug.Log("Score: " + score);
    }
}
