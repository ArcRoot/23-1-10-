using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_HP : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int hp=++GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().hp;
        GameObject.FindGameObjectWithTag("hpmanager").GetComponent<HPManager>().HP_add(hp);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
