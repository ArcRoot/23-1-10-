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

    public TextMesh scoreText; // �Ǵ� public TMPro.TextMeshProUGUI scoreText; (Unity UI Text�� ����ϴ� ���)

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

        // UI Text ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ActivateScoreEffect(int amount)
    {
        scoreEffectActive = true;
        IncreaseScore(amount); // ������ ȿ���� ���� �� �� ���� ����
    }

    public void DeactivateScoreEffect(int amount)
    {
        scoreEffectActive = false;
        IncreaseScore(-amount); // ȿ�� ����� �ٽ� ������ ������ ������
    }

}
