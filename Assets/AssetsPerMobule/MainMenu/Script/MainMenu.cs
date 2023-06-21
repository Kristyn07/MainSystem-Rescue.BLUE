using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject transition;
    public Animator animator;

    private void Start()
    {
        transition.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        animator.SetTrigger("CFadeTransition");
        
    }
    public void ExitGame()
    {
        Debug.Log("Program has exited.");
        Application.Quit();
    }

    
}
