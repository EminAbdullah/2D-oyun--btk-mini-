using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManagerInGame : MonoBehaviour
{
    public GameObject InGameScreen, PauseScreen;
    public void Pause()
    {
        Time.timeScale = 0; // oyunu durdurduk
        InGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale=1;
        InGameScreen.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void RePlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InGameScene");
    }
    public void Home()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene("MenuScene");
    }
}
