using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecker : MonoBehaviour//animation centralize
{
	[SerializeField] bool Stage01;
	[SerializeField] CompletedMiniGame _stage01CheckerTask;

	[SerializeField] bool Stage02;
	[SerializeField] Stage02SubTaskMissions _stage02CheckerTask;

	[SerializeField] bool Stage03;
	[SerializeField] Stage3Missions _stage03CheckerTask;

	[SerializeField] bool Stage04;
	[SerializeField] Stage04Mission _stage04CheckerTask;

	[SerializeField] bool Stage05;
	[SerializeField] Mission05ControlScript _stage05CheckerTask;

	[SerializeField] bool Stage06;
	[SerializeField] Stage06Mission _stage06CheckerTask;

	[SerializeField] bool Stage07;
	[SerializeField] Stage07Mission _stage07CheckerTask;

	[SerializeField] bool Stage08;
    [SerializeField] Stage08SubTaskUI _stage08CheckerTask;

	[SerializeField] bool Stage09;
	[SerializeField] Stage09SubsTask _stage09CheckerTask;

	[SerializeField] bool Stage10;
	[SerializeField] Stage10SubsTask _stage10CheckerTask;

	public void CheckTaskCompleteion() // this is attach to animation
	{
		if (Stage01)
		{
			_stage01CheckerTask.Check_Update();
		}
		else if (Stage02)
		{
			_stage02CheckerTask.Check_Update();
		}
		else if (Stage03)
		{
			_stage03CheckerTask.SubTaskSucess();
		}
		else if (Stage04)
		{
			_stage04CheckerTask.Check_Update();
		}
		else if (Stage05)
		{
			_stage05CheckerTask.Check_Update();
		}
		else if (Stage06)
		{
			_stage06CheckerTask.Check_Update();
		}
		else if (Stage07)
		{
			_stage07CheckerTask.Check_Update();
		}
		else if (Stage08)
		{
			_stage08CheckerTask.StageUpdateMissionStat();
		}
		else if (Stage09)
		{
			_stage09CheckerTask.Check_Update();
		}
		else if (Stage10)
		{
			_stage10CheckerTask.Check_Update();
		}
	}
}
