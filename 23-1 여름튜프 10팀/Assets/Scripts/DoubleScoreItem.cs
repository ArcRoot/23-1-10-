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
            // ScoreManager의 인스턴스를 가져옴
            ScoreManager scoreManager = ScoreManager.instance;

            if (scoreManager != null)
            {
                // 아이템 획득 점수 증가
                scoreManager.IncreaseScore(scoreIncreaseAmount);

                // 아이템 사라짐
                Destroy(gameObject);

                // 효과 타이머 시작
                StartCoroutine(ActivateEffectForDuration(scoreManager));
            }
        }
    }

    IEnumerator ActivateEffectForDuration(ScoreManager scoreManager)
    {
        // 점수 획득 효과 적용
        scoreManager.ActivateScoreEffect(scoreIncreaseAmount);

        // 일정 시간 동안 기다림
        yield return new WaitForSeconds(effectDuration);

        // 점수 획득 효과 해제
        scoreManager.DeactivateScoreEffect(scoreIncreaseAmount);
    }
}
