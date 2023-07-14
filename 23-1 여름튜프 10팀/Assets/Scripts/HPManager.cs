using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public List<GameObject> HP;
    public void HP_add(int hpcnt)
    {
        if (hpcnt <= 10)
        {
            HP.Add(Instantiate<GameObject>(Resources.Load<GameObject>("HP"), new Vector3(-8f + hpcnt * 25f, 920f, 0), Quaternion.identity, GameObject.Find("Canvas").transform));
        }
    }
    public void HP_remove(int hpcnt)
    {
        Destroy(HP[hpcnt]);
        HP.RemoveAt(hpcnt);
    }
    // Start is called before the first frame update
    void Start()
    {
        HP_add(1);
        HP_add(2);
        HP_add(3);
        HP_add(4);
        HP_add(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
