using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Booster : MonoBehaviour // player 오브젝트에 연결
{
    Rigidbody2D rigid;
    private float boostingTimer = 0f;
    private List<ObjectMove> objectMoves = new List<ObjectMove>();

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ObjectMove[] objectMoveScripts = FindObjectsOfType<ObjectMove>();
        foreach (ObjectMove objMove in objectMoveScripts)
        {
            objectMoves.Add(objMove);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "booster")
        {
            Debug.Log("booster");
            boost();
            boostingTimer = 3f;
            other.gameObject.SetActive(false);
        }
    }
    private void boost()
    {
        GetComponent<PlayerMove>().playerspd = 20;
        foreach (ObjectMove objMove in objectMoves)
        {
            objMove.objectspd = 20;
        }
    }
    private void Default()
    {
        GetComponent<PlayerMove>().playerspd = 10;
        foreach (ObjectMove objMove in objectMoves)
        {
            objMove.objectspd = 10;
        }
    }
    void Update()
    {
        if (boostingTimer > 0)
        {
            boostingTimer -= Time.deltaTime;
        }
        else if (boostingTimer <= 0)
        {
            boostingTimer = 0;
            Default();
        }
    }
}