using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoubleScoreItem : MonoBehaviour
{
    public int effectDuration = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ScoreManager�� ���� ���� ������Ʈ���� ScoreManager ������Ʈ�� ������
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            if (scoreManager != null)
            {
                // ������ ȹ�� ���� ����
                scoreManager.IncreaseScore(10);

                // ������ �����
                Destroy(gameObject);

                // ȿ�� Ÿ�̸� ����
                StartCoroutine(ActivateEffectForDuration(scoreManager));
            }
        }
    }

    IEnumerator ActivateEffectForDuration(ScoreManager scoreManager)
    {
        // ȿ���� ScoreManager�� �����Ͽ� Ȱ��ȭ
        scoreManager.ActivateScoreEffect(20);

        // ���� �ð� ���� ��ٸ�
        yield return new WaitForSeconds(effectDuration);

        // ȿ���� ScoreManager�� �����Ͽ� ��Ȱ��ȭ
        scoreManager.DeactivateScoreEffect();
    }
}
