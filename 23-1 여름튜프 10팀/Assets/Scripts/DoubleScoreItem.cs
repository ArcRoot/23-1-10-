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
            // ScoreManager를 가진 게임 오브젝트에서 ScoreManager 컴포넌트를 가져옴
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            if (scoreManager != null)
            {
                // 아이템 획득 점수 증가
                scoreManager.IncreaseScore(10);

                // 아이템 사라짐
                Destroy(gameObject);

                // 효과 타이머 시작
                StartCoroutine(ActivateEffectForDuration(scoreManager));
            }
        }
    }

    IEnumerator ActivateEffectForDuration(ScoreManager scoreManager)
    {
        // 효과를 ScoreManager에 전달하여 활성화
        scoreManager.ActivateScoreEffect(20);

        // 일정 시간 동안 기다림
        yield return new WaitForSeconds(effectDuration);

        // 효과를 ScoreManager에 전달하여 비활성화
        scoreManager.DeactivateScoreEffect();
    }
}
