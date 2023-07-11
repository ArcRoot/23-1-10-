using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComponent_Goal : MonoBehaviour
{
    Goal goal;
    // Start is called before the first frame update
    void Start()
    {   
        goal = gameObject.GetComponent<Goal>();
        goal.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        goal.enabled = true;
        Debug.Log("check");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
