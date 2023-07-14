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
        collision.gameObject.transform.Translate(new Vector3(0, 3.4f, 0));
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
            graceperiod = 2;
            fallchk=false;
        }
        if (graceperiod>0)
        {
            graceperiod -= Time.deltaTime;
            if (graceperiod <= 0)
            {
                graceperiod = 0;
            }
        }
    }
}
