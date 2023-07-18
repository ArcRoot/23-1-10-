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
    }
    public void ChangeStageSelectScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StageSelect");
    }
    public void ChangeStage1Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage1");
    }
    public void ChangeStage2Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage2");
    }
    public void ChangeStage3Scene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage3");
    }
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
    public void Restart_Level()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastLoadedScene"));
    }
    public void Exit()
    {
        Application.Quit();
    }
    /*public void ChangeInfiniteModeScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("InfiniteMode");
    }*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}