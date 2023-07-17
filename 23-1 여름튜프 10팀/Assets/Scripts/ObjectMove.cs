using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public int objectspd;
    // Start is called before the first frame update
    private void move()
    {
        float objmove= Time.deltaTime* objectspd;
        transform.Translate(objmove, 0, 0);
    }
    
    public void game_end()
    {
        objectspd= 0;
    }
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        move();
    }
}
