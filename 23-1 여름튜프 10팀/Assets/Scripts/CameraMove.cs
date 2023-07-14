using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float camspd;
    private void move()
    {
        float cammove = Time.deltaTime * camspd;
        transform.Translate(cammove, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
