using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadGameObject : MonoBehaviour
{
	//[SerializeField] public GameObject[] DontDestroy;
	//[SerializeField] public GameObject[] DoDestroy;

	public int buildIndex;
	public int GameObjCount = 5;
	public int Length = 0;
	public void Start()
	{
		
	}

	public void Update()
	{
		
		Scene scene;
		scene = SceneManager.GetActiveScene();
		buildIndex = scene.buildIndex;
		DontDestroyObj();
	}

	void DontDestroyObj()
	{
		//if (buildIndex >= 2) {
		//	foreach (GameObject Obj in DontDestroy)
		//	{
		//		DontDestroyOnLoad(Obj);
		//	}
		//}
		
		
		//else if (buildIndex <= 1)
		//{
		//	foreach (GameObject Obj in DontDestroy)
		//	{
		//		Destroy(Obj);
		//	}
		//}

		
	}

	public void replyDestroy()
	{
		//if (buildIndex == 2) 
		//{ 
		//	foreach (GameObject Obj in DontDestroy)
		//		{
		//			Destroy(Obj);
		//		}
		//}
	}

	
}
