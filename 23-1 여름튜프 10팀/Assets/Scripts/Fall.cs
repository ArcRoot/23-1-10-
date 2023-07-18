using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private bool fallchk=false;
    private float graceperiod = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("fall");
        collision.gameObject.transform.Translate(new Vector3(2, 5, 0));
        collision.gameObject.GetComponent<PlayerMove>().playerspd = 0;
        GameObject.FindGameObjectWithTag("MainCamera").transform.Translate(new Vector3(2, 0, 0));
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectMove>().objectspd = 0;
        GameObject.FindGameObjectWithTag("destroybar").GetComponent<ObjectMove>().objectspd = 0;
        transform.Translate(new Vector3(2, 0, 0));
        gameObject.GetComponent<ObjectMove>().objectspd = 0;
        graceperiod = 3;
        fallchk=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fallchk)
        {
            if (graceperiod > 0)
            {
                graceperiod -= Time.deltaTime;

            }
            else if (graceperiod <= 0)
            {
                graceperiod = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().playerspd = 10;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectMove>().objectspd = 10;
                GameObject.FindGameObjectWithTag("destroybar").GetComponent<ObjectMove>().objectspd = 10;
                gameObject.GetComponent<ObjectMove>().objectspd = 10;
                fallchk =false;
            }
        }
    }
}
