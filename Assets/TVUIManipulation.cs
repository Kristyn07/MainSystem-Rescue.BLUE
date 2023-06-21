using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stage080910;

public class TVUIManipulation : MonoBehaviour
{
	[SerializeField] PlugConnection plugManager;
	[SerializeField] GameObject OffTVGameObj;
	[SerializeField] GameObject OnTVGameObj;
	[SerializeField] GameObject OW_OffTVGameObj;
	[SerializeField] GameObject OW_OnTVGameObj;
	[SerializeField] GameObject OnBTN;
	[SerializeField] GameObject OffBTN;
	[SerializeField] CableConnector OnAndOffButton;

	

	public void OnTV() //the TV if on so activate the off button
	{
		OnAndOffButton.IsConnected = false;
		OffTVGameObj.SetActive(true);
		OW_OffTVGameObj.SetActive(true);

		OW_OnTVGameObj.SetActive(false);
		OffBTN.SetActive(true);
		OnBTN.SetActive(false);
		OnTVGameObj.SetActive(false);
	}

	public void OffTV() //the TV if off so activate the on button
	{
		OnAndOffButton.IsConnected = true;
		OnTVGameObj.SetActive(true);
		OW_OnTVGameObj.SetActive(true);
		OW_OffTVGameObj.SetActive(false);
		OnBTN.SetActive(true);
		OffBTN.SetActive(false);
		OffTVGameObj.SetActive(false);
	}

	




}
