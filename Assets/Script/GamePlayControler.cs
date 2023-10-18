using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GamePlayControler : MonoBehaviour
{
    [SerializeField]
    private GameObject pousepanel;
    public AudioSource music;
  
    public void PauseGameButton()
    {
        pousepanel.SetActive(true);
        Time.timeScale = 0f;
        music.Pause();

    }
    public void ResumeButton()
    {
        pousepanel.SetActive(false);
        Time.timeScale = 1f;
        music.UnPause();
    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        music.UnPause();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        music.UnPause();
    }
}
