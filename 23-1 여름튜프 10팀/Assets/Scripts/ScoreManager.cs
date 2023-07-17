using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;
    private float timer = 0f;
    private float scoreInterval = 10f;
    private bool scoreEffectActive = false;

    public TextMesh scoreText; // 또는 public TMPro.TextMeshProUGUI scoreText; (Unity UI Text를 사용하는 경우)

    private void Awake()
    {
        // ScoreManager 인스턴스 생성 또는 중복 방지
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        while (timer >= scoreInterval && !scoreEffectActive)
        {
            timer -= scoreInterval;
            IncreaseScore(scoreEffectActive ? 2 : 1);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        // UI Text 업데이트
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ActivateScoreEffect(int amount)
    {
        scoreEffectActive = true;
        IncreaseScore(amount); // 아이템 효과로 인한 두 배 점수 증가
    }

    public void DeactivateScoreEffect(int amount)
    {
        scoreEffectActive = false;
        IncreaseScore(-amount); // 효과 종료로 다시 원래의 점수로 돌리기
    }

}
