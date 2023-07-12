using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore : MonoBehaviour
{
    public float ignoreTime = 2f;
    private float timer = 0f;
    private bool isIgnoring = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isIgnoring)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
            isIgnoring = true;
            timer = 0f;
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isIgnoring)
        {
            timer += Time.deltaTime;
            if (timer >= ignoreTime)
            {
                PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
                if (polygonCollider != null && polygonCollider.enabled)
                {
                    Collider2D[] allColliders = GetComponents<Collider2D>();
                    foreach (Collider2D collider in allColliders)
                    {
                        Physics2D.IgnoreCollision(polygonCollider, collider, false);
                    }
                }

                gameObject.SetActive(true);
                isIgnoring = false;
            }
        }
    }
}
