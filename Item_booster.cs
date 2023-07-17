using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_booster : MonoBehaviour
{
    private float boostingTimer = 0f;
    private bool isBoosting = false;
    private PlayerMove boostingPlayer; // PlayerMove 컴포넌트를 참조할 변수
    private void StartBoosting(Collider2D collision)
    {
        isBoosting = true;
        boostingTimer = 0f;
        boostingPlayer = collision.gameObject.GetComponent<PlayerMove>();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("booster");
        StartBoosting(collision); // 부스팅 시작
    }
    void Update()
    {
        if (isBoosting)
        {
            boostingTimer += Time.deltaTime; // 경과한 시간을 누적

            if (boostingTimer >= 3f) // 3초 동안 작동했을 때
            {
                isBoosting = false;
                boostingTimer = 0f;
            }
            else
            {
                boostingPlayer.boosting(); // 부스팅 함수 호출
            }
        }
    }
    void Start()
    {

    }
}