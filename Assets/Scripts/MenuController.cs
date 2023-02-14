using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject winGameLog;
    public GameObject loseGameLog;

    public void WinGame()
    {
        PauseGame();
        winGameLog.SetActive(true);
    }

    public void LoseGame()
    {
        PauseGame();
        loseGameLog.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void BackMenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
