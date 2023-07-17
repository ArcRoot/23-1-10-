using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Arrow : MonoBehaviour
{
    private GameObject Player;
    private void shoot_arrow()
    {
        if (transform.position.x - Player.transform.position.x < 30)
        {
            GetComponent<ObjectMove_Arrow>().objectspd = 5;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shoot_arrow();
    }
}
