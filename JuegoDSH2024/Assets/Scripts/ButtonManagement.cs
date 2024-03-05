using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public void StartLevelMode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        
    }

      public void StartInfiniteMode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("InfiniteScene", LoadSceneMode.Single);
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
    }
}
