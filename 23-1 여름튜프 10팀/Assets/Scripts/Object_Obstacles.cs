using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Obstacles : MonoBehaviour
{
    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().DecreaseHP(damage);
            Debug.Log("�÷��̾��� ���� ü�� : " + collision.gameObject.GetComponent<PlayerHP>().hp);
        }
    }
}
