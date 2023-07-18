using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //GameObject[] enemys;
    //GameObject[] objects;
    private void OnTriggerEnter2D(Collider2D player)
    {
        /*for (int i = 0; i<enemys.Length; i++)
        {
            enemys[i].GetComponent<ObjectMove>().game_end();
        }*/
        //gameObject.GetComponent<ObjectMove>().game_end();
        //player.gameObject.GetComponent<PlayerMove>().goal();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectMove>().objectspd = 0;
        GameObject.FindGameObjectWithTag("destroybar").GetComponent<ObjectMove>().objectspd = 0;
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.gameObject.GetComponent<Collider2D>());
    }
    // Start is called before the first frame update
    void Start()
    {
        //enemys = GameObject.FindGameObjectsWithTag("enemy");
        //objects = GameObject.FindGameObjectsWithTag("object");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
