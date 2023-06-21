using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMiniGame : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject Information;
    public void ResumeMiniGameButton()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseMiniGameButton()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }


    public void InfoMiniGameButton()
    {
        Information.SetActive(true);
        
    }

    public void InfoExitMiniGameButton()
    {
        
        Information.SetActive(false);
    }
}
