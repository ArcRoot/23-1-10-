using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;
    private float scoreInterval = 1f; // 1초마다 점수가 오르도록 설정
    private int scoreEffectAmount = 0; // 효과로 인해 증가되는 점수
    private bool scoreEffectActive = false;

    public TextMeshProUGUI scoreText;

    private float lastScoreIncreaseTime = 0f; // 마지막으로 점수를 증가시킨 시간 저장

    private Coroutine scoreEffectCoroutine; // Coroutine을 저장할 변수

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

    private void Update()
    {
        // 시간에 따라 점수 증가
        if (scoreEffectActive)
        {
            if (Time.time >= lastScoreIncreaseTime + scoreInterval)
            {
                lastScoreIncreaseTime = Time.time;
                IncreaseScore(scoreEffectAmount);
            }
        }
        else
        {
            if (Time.time >= lastScoreIncreaseTime + scoreInterval)
            {
                lastScoreIncreaseTime = Time.time;
                IncreaseScore(10); // 아이템을 획득하지 않았을 때 일반적으로 10점씩 점수가 오르도록 설정
            }
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
        if (!scoreEffectActive) // 효과가 활성화되지 않은 경우만 동작
        {
            scoreEffectActive = true;
            scoreEffectAmount = amount;

            // Coroutine 시작 또는 재시작
            if (scoreEffectCoroutine != null)
            {
                StopCoroutine(scoreEffectCoroutine);
            }
            scoreEffectCoroutine = StartCoroutine(DeactivateScoreEffectAfterDuration());
        }
    }

    IEnumerator DeactivateScoreEffectAfterDuration()
    {
        yield return new WaitForSeconds(10f); // 10초간 기다림

        scoreEffectActive = false;
        scoreEffectAmount = 0;
    }

    // 효과를 직접 해제할 수 있는 메서드 추가
    public void DeactivateScoreEffect()
    {
        scoreEffectActive = false;
        scoreEffectAmount = 0;
    }
}
