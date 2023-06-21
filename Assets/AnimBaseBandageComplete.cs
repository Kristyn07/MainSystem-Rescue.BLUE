using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegCravatMiniTask;

public class AnimBaseBandageComplete : MonoBehaviour
{
	[SerializeField] bool ApplyThisScript;
	[SerializeField] TaskIsComplete _taskIsComplete;//1
	[Header("For2Step")] 
	[SerializeField] bool Stage02;
	[SerializeField] LegCravatStepsController _check_Update_2;

	[SerializeField] bool DontNeedThis;

	[SerializeField] LegCravatStepsController S7Hip;
	[SerializeField] TopOfTheHeadBandaging S7Head;
	[SerializeField] LegCravatStepsController S7Arm;
	public void OnEndAnim()
	{
		if (ApplyThisScript == true)
		{
			if (Stage02)
			{
				_check_Update_2.Check_Update();
				 if (!DontNeedThis)
				{
					if (_taskIsComplete != null)
					{
						_taskIsComplete.Completed();
					}
					
				}
				
			}
			else
			{
				_taskIsComplete.Completed();
			}

		}

	} //1 -6

	public void S7EndHip()
	{
		S7Hip.Check_Update();
	}
	public void S7EndHead()
	{
		//S7Head.Check_Update();
	}
	public void S7EndArm()
	{
		S7Arm.Check_Update();
	}
}
