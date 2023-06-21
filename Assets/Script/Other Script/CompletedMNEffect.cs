/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedMNEffect : MonoBehaviour
{
    public Objectives __objectives; // for first aid kit
	public GameObject[] completeanim;
	public TaskIsComplete _taskIsComplete;

	
	private void Update()
	{
		CheckMissionCompletion();
		
		
	}

	
	void CheckMissionCompletion()
	{

		if (__objectives.isComplete == true)
		{
			completeanim[0].SetActive(true);
			
		}

		if (_taskIsComplete.isComplete == true)
		{
			Invoke("FirstAidCompleted", 2);
			
		}
	}
	
	void FirstAidCompleted()
	{
		completeanim[1].SetActive(true);
	}
}
*/