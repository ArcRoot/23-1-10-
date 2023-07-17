using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void ChangeStartScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Start");
    }/*
    public void ChangeLevel1Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level1");
    }
    public void ChangeLevel2Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level2");
    }
    public void ChangeLevel3Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level3");
    }
    public void ChangeInfiniteModeScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("InfiniteMode");
    }*/
    public void ChangeGameClearScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameClear");
    }
    public void ChangeDieScene()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Die");
    }
    public void ChangePauseScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Pause");
    }
    public void ChangeTestScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Test");
    }
    public void Restart_Level()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
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