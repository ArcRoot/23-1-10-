using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_level : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
