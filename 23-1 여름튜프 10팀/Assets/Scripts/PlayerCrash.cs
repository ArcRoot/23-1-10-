using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    Rigidbody2D rigid;
    void start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GetComponent<PlayerHP>().DecreaseHP(damage);
            Debug.Log("�÷��̾��� ���� ü�� : "+ GetComponent<PlayerHP>().hp);
        }
    }
}
