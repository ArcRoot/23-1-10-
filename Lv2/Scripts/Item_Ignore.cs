using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item_Ignore : MonoBehaviour // player 오브젝트에 연결
{
    Rigidbody2D rigid;
    Collider2D other;
    SpriteRenderer spriteRenderer;
    private float ignoringTimer = 0f;
    List<Collider2D> enemys = new List<Collider2D>();

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        other = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D[] taggedObjectsArray = GameObject.FindGameObjectsWithTag("enemy")
                                                    .Select(obj => obj.GetComponent<Collider2D>())
                                                    .ToArray();

        foreach (Collider2D e in taggedObjectsArray)
        {
            enemys.Add(e);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "booster" || collision.gameObject.tag == "ignore")
        {
            Debug.Log("ignore");
            ignore();
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            ignoringTimer = 3f;
            collision.gameObject.SetActive(false);
        }
    }
    private void ignore()
    {
        foreach (Collider2D enemyCollider in enemys)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemyCollider, true);
        }
    }
    private void Default()
    {
        foreach (Collider2D enemyCollider in enemys)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemyCollider, false);
        }
    }
    void Update()
    {
        if (ignoringTimer > 0)
        {
            ignoringTimer -= Time.deltaTime;
        }
        else if (ignoringTimer <= 0)
        {
            ignoringTimer = 0;
            Default();
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}