using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    private bool isBoosting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // 플레이어와 충돌한 경우
        {
            isBoosting = true;
            GetComponent<ObjectMove>().objectspd=-20;
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (isBoosting)
        {
            StartCoroutine(Time(2f));
        }
    }

    private IEnumerator Time(float delay)
    {
        yield return new WaitForSeconds(delay);

        GetComponent<ObjectMove>().objectspd = -10;

        gameObject.SetActive(true);

        isBoosting = false;
    }
}
