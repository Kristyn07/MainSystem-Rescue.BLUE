using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    // wait for spash screen to play 
    public float waitTime = 5f;
    [SerializeField] GameObject LoadingBar;
    [SerializeField] Slider Slider;
    [SerializeField] AudioSource Bgm;

    void Start()
    {
       

        StartCoroutine(Wait_for_intro());
        

    }

    IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(LoadSceneAsynchronously());
    }

    IEnumerator LoadSceneAsynchronously()
    {
        
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        LoadingBar.SetActive(true);
        Bgm.Play();
        while (!operation.isDone)
        {

            Slider.value = operation.progress;
            Debug.Log("Loading..." + operation.progress);
            yield return null;
        }
    }
}
