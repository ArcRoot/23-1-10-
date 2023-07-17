using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ignore : MonoBehaviour
{
    private float ignoringTimer = 0f;
    private bool isignoring = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D collision;

    private void StartIgnoring()
    {
        isignoring = true;
        ignoringTimer = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 컴포넌트를 가져옴
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ignore"))
        {
            Debug.Log("ignore");
            other.gameObject.SetActive(false); //아이템 사라짐
            collision = other.GetComponent<Collider2D>();
            StartIgnoring(); // 무적 시작
        }
    }

    private void Update()
    {
        if (isignoring)
        {
            ignoringTimer += Time.deltaTime; // 경과한 시간을 누적
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), true);

            if (ignoringTimer >= 3f) // 3초 동안 작동했을 때
            {
                isignoring = false;
                ignoringTimer = 0f;
                spriteRenderer.color = new Color(1, 1, 1, 1); //무적 타임 종료(원래대로)
                Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), false);
            }
        }
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 컴포넌트를 가져옴
    }
}