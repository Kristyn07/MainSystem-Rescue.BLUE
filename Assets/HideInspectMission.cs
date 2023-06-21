using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LegCravatMiniTask;
public class HideInspectMission : MonoBehaviour
{
    //for stage 7 only

    [SerializeField] Canvas MiniGameCanvas;
    [SerializeField] Canvas PlayerCanvas;
	[SerializeField] GameObject[] CurrentWindow;

	[SerializeField] LegCravatStepsController hip;
	[SerializeField] GameObject hipcomplete;

	[SerializeField] TopOfTheHeadBandaging topofthehead;
	[SerializeField] GameObject topoftheheadcomplete;

	[SerializeField] SlingArmAnimationController slingarm;
	[SerializeField] GameObject slingarmcomplete;
	public void HideInspectMissionBandage()

	{
		MiniGameCanvas.enabled = false;
		PlayerCanvas.enabled = true;
		foreach (GameObject obj in CurrentWindow) { obj.SetActive(false); }
		check();
	}

	public void check()
	{
		if (hip.IsSuccess == true)
		{
			hipcomplete.SetActive(true);
		}
		if (slingarm.isSuccess == true)
		{
			slingarmcomplete.SetActive(true);
		}
		if (topofthehead.isSuccess == true)
		{
			topoftheheadcomplete.SetActive(true);
		}
	}
}
