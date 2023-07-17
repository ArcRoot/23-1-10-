using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float jumpPower;
    public float sjpower;
    public int jumpcnt=0;
    public int playerspd=0;

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpcnt!=0)
            {
                jumpcnt--;
                rigid.AddForce(Vector3.up*jumpPower,ForceMode2D.Impulse);
            }
        }
    }
    void slide()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(new Vector3(0, -0.5f, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 2, 1);
        }
    }
    public void superjump()
    {
        jumpcnt = 0;
        rigid.AddForce(Vector3.up * sjpower, ForceMode2D.Impulse);
    }
    private void move()
    {
        float playermove = Time.deltaTime * playerspd;
        transform.Translate(playermove, 0, 0);
    }

    public void goal()
    {
        playerspd= 10;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("bottom")) 
        {
            jumpcnt = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        slide();
        move();
    }
}
