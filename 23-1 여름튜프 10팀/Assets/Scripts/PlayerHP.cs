using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hp;
    public int maxHP = 5;

    void Start()
    {
        hp = maxHP;
    }

    void Update()
    {
        /*if (HPManager.Instance != null)
        {
            HPManager.Instance.SetHP(hp, maxHP);
            if (hp <= 0)
            {
                HPManager.Instance.SetGameOver();
            }
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }*/
    }
    public void DecreaseHP(int Damage)
    {
        hp -= Damage;
    }
}
