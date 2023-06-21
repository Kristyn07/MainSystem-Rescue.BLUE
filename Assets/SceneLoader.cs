using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MainScene.Manager;
public class SceneLoader : MonoBehaviour
{

	public GameObject loadingScreen;
	public Slider LoadingBar;
	//public TMPro.TextMeshProUGUI LoadingCount;
	MainMenuManagerScript _mainMenuManagerScript;
	[SerializeField] GameObject FadeTransition;

	private float delaySecs = 6f;
	
	public void LoadScene(int levelIndex)
	{
		FadeTransition.SetActive(true);
		loadingScreen.SetActive(true);
		//StartCoroutine(LoadSceneAsynchronously(levelIndex, delaySecs));
		StartCoroutine(LoadSceneAsynchronously(levelIndex));
	}

	public void LoadContinueScene()
	{

		StartCoroutine(LoadSceneAsynchronously(_mainMenuManagerScript.ContinueCount));
		//StartCoroutine(LoadSceneAsynchronously(_mainMenuManagerScript.ContinueCount, delaySecs));
	}


	IEnumerator LoadSceneAsynchronously(int levelIndex)
	{
		yield return new WaitForSeconds(delaySecs);
		AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
		while (!operation.isDone)
		{
			LoadingBar.value = operation.progress;
			Debug.Log("Loading..." + operation.progress);
			yield return null;
		}
	}

	
}
