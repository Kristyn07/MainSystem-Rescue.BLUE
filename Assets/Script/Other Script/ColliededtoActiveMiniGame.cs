using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliededtoActiveMiniGame : MonoBehaviour
{
	//SFX sound Storage 
	public GameObject MN1;
	public GameObject MN2;

	[Header("Button Sound")]
	public AudioSource OnclickButton;

	[Header("Game Play Sound Effects")]
	public AudioSource CollidedtoMN;
	public AudioSource CollidedtoGuide;

	[Header("MN1 Objective Update")]
	public Objectives _objectivess;

	private void Update()
	{
		//
	}

	public void detectedMN()
	{

		bool mncompleted = _objectivess.isComplete;

		if (mncompleted == false && MN1.activeSelf)
		{
				CollidedtoMN.Play();	
		}
		
		if (MN2.activeSelf)
		{
			CollidedtoMN.Play();
		}
	}
}
