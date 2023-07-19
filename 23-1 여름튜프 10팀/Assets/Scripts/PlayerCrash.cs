using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    Rigidbody2D rigid;
    private float c_time = 0;

    void start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "fall") // 무적 아이템 먹었을 때 fall이 enemy로 분류되어 무시되는 것 방지 
        {
            color_change_R();
            GetComponent<PlayerHP>().DecreaseHP(damage);
            Debug.Log("플레이어의 남은 체력 : "+ GetComponent<PlayerHP>().hp);
            c_time = 0.1f;
        }
    }
    private void color_change_R()
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
    }
    private void color_change_W()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
    }
    void Update()
    {
        if(c_time > 0 )
        {
            c_time-= Time.deltaTime;
        }
        else if (c_time <= 0)
        {
            c_time= 0;
            color_change_W();
        }
    }
}
