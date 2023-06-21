using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelocatePlayer : MonoBehaviour
{
	[Header("Transform Player")]
	[SerializeField] GameObject Player;
	[SerializeField] Transform CurrentLocation;
	[SerializeField] Transform TutorialLoc;
	[SerializeField] Transform GameplayLoc;
	[SerializeField] Vector3 playerloc;
	[SerializeField] Vector3 LocTutorial;
	[SerializeField] Vector3 LocGameplay;

	[Header("Bool")]
	[SerializeField] bool IsTutorialMode;
	[SerializeField] bool GamePlayMode;

	[Header("GetScript")]
	[SerializeField] DialogManager_GamePlay _dialogManager_Gameplay;
	[SerializeField] DialogManager_Toturial _dialogManager_Toturial;

	public void Awake()
	{
		//int value = (PlayerPrefs.GetInt("Reply");


		if (PlayerPrefs.GetInt("Reply") == 1)
		{
			GamePlayStart();

		}

		else if (PlayerPrefs.GetInt("Reply") == 0)
		{
			TutorialMode();
		}
	}

	public void Start()
	{
		LocTutorial = new Vector3(TutorialLoc.position.x, TutorialLoc.position.y, 0f);
		LocGameplay = new Vector3(GameplayLoc.position.x, GameplayLoc.position.y, 0f);
	}

	public void Update()
	{

		PlayerPrefs.GetInt("Reply");
		//
		playerloc = new Vector3(CurrentLocation.position.x, CurrentLocation.position.y, 0f);
		IsTutorialMode = _dialogManager_Toturial.isinToturialMode;
	}
	public void TutorialMode()
	{
		//playerloc = new Vector3
		
		if (IsTutorialMode == true){
			//playerloc = new Vector3 (LocTutorial.x, LocTutorial.y, -999f);
			Player.transform.position = new Vector3(TutorialLoc.position.x, TutorialLoc.position.y, 0f);
		}
		else{
			//GamePlayStart();
		}
	}

	public void GamePlayStart()
	{
		Player.transform.position = new Vector3(GameplayLoc.position.x, GameplayLoc.position.y, 0f);
	}







}
