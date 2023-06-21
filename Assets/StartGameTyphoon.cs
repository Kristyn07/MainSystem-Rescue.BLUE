using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;

public class StartGameTyphoon : MonoBehaviour
{
	[Header("StartTyphoon")]
	[SerializeField] TyphoonGamePlayStage09 _typhoonGamePlayStage09;
	[SerializeField] GameObject DarkenAll;
	[SerializeField] GameObject Light;
	[SerializeField] GameObject[] Storage;
	[SerializeField] Color DarkenColor;
	private Image LightImage;
	private Image DarkenImage;

	[Header("Change GamePlay")]
	[SerializeField] LevelGameplayManagerScript MainManager;
	[SerializeField] GameObject DisplayMission;
	[SerializeField] Image SliderFill;
	[SerializeField] Color HealthColor;

	private void Start()
	{
		LightImage = Light.GetComponent<Image>();
		DarkenImage = DarkenAll.GetComponent<Image>();
	}
	
	public IEnumerator OrderExecution()
	{
		yield return new WaitForSeconds(0f);
		DarkenImage.color = DarkenColor;
		LightImage.enabled = true;
		_typhoonGamePlayStage09.FlashLightBehavior(); 
		foreach (GameObject obj in Storage)
		{
			obj.SetActive(true);
		}
		DisplayMission.SetActive(false);
		MainManager.StartGameplay = false;
		MainManager.ReputationBar.value = 100;
		SliderFill.color = HealthColor;


		_typhoonGamePlayStage09.GameplayStartTyphoon = true;

	}
}
