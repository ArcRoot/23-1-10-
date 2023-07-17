using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleScoreItem : MonoBehaviour
{
    public int scoreIncreaseAmount = 10;
    public float effectDuration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ScoreManager�� �ν��Ͻ��� ������
            ScoreManager scoreManager = ScoreManager.instance;

            if (scoreManager != null)
            {
                // ������ ȹ�� ���� ����
                scoreManager.IncreaseScore(scoreIncreaseAmount);

                // ������ �����
                Destroy(gameObject);

                // ȿ�� Ÿ�̸� ����
                StartCoroutine(ActivateEffectForDuration(scoreManager));
            }
        }
    }

    IEnumerator ActivateEffectForDuration(ScoreManager scoreManager)
    {
        // ���� ȹ�� ȿ�� ����
        scoreManager.ActivateScoreEffect(scoreIncreaseAmount);

        // ���� �ð� ���� ��ٸ�
        yield return new WaitForSeconds(effectDuration);

        // ���� ȹ�� ȿ�� ����
        scoreManager.DeactivateScoreEffect(scoreIncreaseAmount);
    }
}
