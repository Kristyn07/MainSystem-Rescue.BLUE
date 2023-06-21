using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivateHuman : MonoBehaviour
{
    public CravatNarrowFolding _cravatNarrowFolding;
	public GameObject humanwireframe;
	private void Update()
	{
		if (_cravatNarrowFolding.isSuccess == true) 
		{

			humanwireframe.SetActive(true);


		}
	}
	
}
