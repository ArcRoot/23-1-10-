using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score = 0;
    private float scoreInterval = 1f; // 1�ʸ��� ������ �������� ����
    private int scoreEffectAmount = 0; // ȿ���� ���� �����Ǵ� ����
    private bool scoreEffectActive = false;

    public TextMeshProUGUI scoreText;

    private float lastScoreIncreaseTime = 0f; // ���������� ������ ������Ų �ð� ����

    private Coroutine scoreEffectCoroutine; // Coroutine�� ������ ����

    private void Awake()
    {
        // ScoreManager �ν��Ͻ� ���� �Ǵ� �ߺ� ����
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
        // �ð��� ���� ���� ����
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
                IncreaseScore(10); // �������� ȹ������ �ʾ��� �� �Ϲ������� 10���� ������ �������� ����
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        // UI Text ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ActivateScoreEffect(int amount)
    {
        if (!scoreEffectActive) // ȿ���� Ȱ��ȭ���� ���� ��츸 ����
        {
            scoreEffectActive = true;
            scoreEffectAmount = amount;

            // Coroutine ���� �Ǵ� �����
            if (scoreEffectCoroutine != null)
            {
                StopCoroutine(scoreEffectCoroutine);
            }
            scoreEffectCoroutine = StartCoroutine(DeactivateScoreEffectAfterDuration());
        }
    }

    IEnumerator DeactivateScoreEffectAfterDuration()
    {
        yield return new WaitForSeconds(10f); // 10�ʰ� ��ٸ�

        scoreEffectActive = false;
        scoreEffectAmount = 0;
    }

    // ȿ���� ���� ������ �� �ִ� �޼��� �߰�
    public void DeactivateScoreEffect()
    {
        scoreEffectActive = false;
        scoreEffectAmount = 0;
    }
}
