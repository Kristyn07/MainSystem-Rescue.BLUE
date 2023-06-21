using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropCoverHoldTrigger : MonoBehaviour
{
	public bool IsStanding;
	public bool IsCrawling;

	public void Standing()
	{
		IsStanding = true;
		IsCrawling = false;
	}

	public void Crawling()
	{
		IsCrawling = true;
		IsStanding = false;
	}
	
}
