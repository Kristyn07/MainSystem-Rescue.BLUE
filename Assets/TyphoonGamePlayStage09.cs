using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score.System;
public class TyphoonGamePlayStage09 : MonoBehaviour
{
	[SerializeField] ScoreManagerScriptStages MainScoreStage;
	public bool GameplayStartTyphoon;
	[SerializeField] float Current_TimerGamePlay;
	[SerializeField] float Max_TimerGamePlay;
	[SerializeField] float ReduceDamageWhenOutsideHouse;
	[SerializeField] MainPlayerMovementScript Movement;
	//public BoxCollider2D boxCollider;


	[Header("Main Health Bar")]
	public Slider HealthBar;
	public float CurrentHealth;
	[SerializeField] float MaxHealth;

	[Header("Flash Light")]
	[SerializeField] bool L_WithBattery;
	[SerializeField] bool OnFlashLight;
	[SerializeField] Color OnColor;
	[SerializeField] Color OffColor;
	[SerializeField] Image Darken;
	[SerializeField] Color IconOnColor;
	[SerializeField] Color IconOffColor;
	[SerializeField] Image FlashLightIcon;
	[SerializeField] GameObject Light;
	public Slider LightSlider;
	public float L_Timer;
	public float L_MaxTimer;

	[Header("Phone")]
	[SerializeField] bool OnPhone;
	[SerializeField] GameObject PhonePanel;
	[SerializeField] GameObject MainController;
	[SerializeField] GameObject HideStorageBTN;

	[Header("Storage")]
	[SerializeField] bool OnStorage;
	[SerializeField] GameObject StoragePanel;
	[SerializeField] GameObject HidePhoneBTN;

	[Header("RelocateItem")]
	[SerializeField] GameObject[] Items;
	[SerializeField] GameObject[] Item_ParentObjectClass;

	[Header("Food")]
	public Slider FoodSlider;
	public float F_Timer;
	public float F_MaxTimer;

	[Header("Water")]
	public Slider WaterSlider;
	public float W_Timer;
	public float W_MaxTimer;

	[Header("Condition State")]
	[SerializeField] GameObject LoseCollection;
	[SerializeField] GameObject WinCollection;
	[SerializeField] bool StageComplete;

	[Header("Typhoon Update Notification Pop Up")]
	[SerializeField] bool[] anim;
	[SerializeField] Text Message;
	[SerializeField] GameObject MessagePopUp;
	[SerializeField] GameObject[] Bubble;
	[SerializeField] ParticleSystem Rain;

	[Header("Typhoon Restore Light")]
	[SerializeField] Button LightButton;
	[SerializeField] Image DarkenColor;
	[SerializeField] Color LighterColor;
	[SerializeField] GameObject Offlight;
	public void Start()
	{
		SetStateOnStart();
		FlashLightBehavior();
		PhoneBehavior();
	}
	private void Update()
	{
		
		if (GameplayStartTyphoon)
		{
			Stage09WinCondition();
			LightSliderBehavior();
			FoodSliderBehavior();
			WaterSliderBehavior();
			MainHealthBar();
		}
	}
	public void FlashLightBehavior()
	{
		if (L_WithBattery)
		{
			if (OnFlashLight)//onn
			{
				FlashLightIcon.color = IconOnColor;
				if (GameplayStartTyphoon)
				{
					Darken.color = OffColor;
				}
				Light.SetActive(true);
				OnFlashLight = false; // activate off button
			}
			else //off
			{
				FlashLightIcon.color = IconOffColor;
				if (GameplayStartTyphoon)
				{
					Darken.color = OnColor;
				}
				Light.SetActive(false);
				OnFlashLight = true; //activate on button
			}
		}
		else
		{
			FlashLightIcon.color = IconOffColor;
			if (GameplayStartTyphoon)
			{
				Darken.color = OnColor;
			}
			Light.SetActive(false);
			OnFlashLight = true; //activate on button
		}
		
	}
	public void PhoneBehavior()
	{
		if (OnPhone)
		{
			//Movement.enabled = false;
			Movement.IdleButton();
			MainController.SetActive(false);
			PhonePanel.SetActive(true);
			HideStorageBTN.SetActive(true);
			OnPhone = false;
		}
		else
		{
			//Movement.enabled = true;
			Movement.IdleButton();
			MainController.SetActive(true);
			PhonePanel.SetActive(false);
			HideStorageBTN.SetActive(false);
			OnPhone = true;
		}
	}
	public void StorageBehavior()
	{
		if (OnStorage)
		{
			//Movement.enabled = false;
			Movement.IdleButton();
			MainController.SetActive(false);
			StoragePanel.SetActive(true);
			HidePhoneBTN.SetActive(true);
			OnStorage = false;
		}
		else
		{
			//Movement.enabled = true;
			Movement.IdleButton();
			MainController.SetActive(true);
			StoragePanel.SetActive(false);
			HidePhoneBTN.SetActive(false);
			OnStorage = true;
		}
	}
	public void LightSliderBehavior()
	{
		if (OnFlashLight == false)//meaning the light is on
		{
			//LightSlider.value -= ReduceLight;
			// Timer
			LightSlider.value = L_Timer / L_MaxTimer;
			L_Timer -= Time.deltaTime;

			//ThisWill Happen When it reaches 0 or less than
			if (L_Timer <= 0)
			{
				L_Timer = 0;
				if (OnFlashLight == false)
				{
					FlashLightIcon.color = IconOffColor;
					if (GameplayStartTyphoon)
					{
						Darken.color = OnColor;
					}
					Light.SetActive(false);
					OnFlashLight = true; //activate on button
					OnFlashLight = true;
					L_WithBattery = false;
				}
			}
			else
			{
				L_WithBattery = true;


			}
		}
		else
		{
			LightSlider.value = L_Timer / L_MaxTimer;
			if (L_Timer > 0)
			{
				L_WithBattery = true;
			}
			
		}
	}
	public void FoodSliderBehavior()
	{
		//FoodSlider.value -= ReduceFood;
		//Timed
		FoodSlider.value = F_Timer / F_MaxTimer;
		F_Timer -= Time.deltaTime;

		//ThisWill Happen When it reaches 0 or less than
		if (FoodSlider.value <= 0)
		{
			F_Timer = 0;
		}
	}
	public void WaterSliderBehavior()
	{
		//WaterSlider.value -= ReduceWater;
		WaterSlider.value = W_Timer / W_MaxTimer;
		W_Timer -= Time.deltaTime;

		//ThisWill Happen When it reaches 0 or less than
		if (WaterSlider.value <= 0)
		{
			W_Timer = 0;
		}
	}
	public void SetStateOnStart()
	{
		//Main Health Bar
		MaxHealth = (W_MaxTimer + F_MaxTimer) * 0.9f;
		CurrentHealth = (W_Timer + F_Timer) * 0.9f;
		//HealthBar.value = CurrentHealth / MaxHealth;
		//Food
		FoodSlider.value = F_Timer / F_MaxTimer;
		//Water
		WaterSlider.value = W_Timer / W_MaxTimer;
		//Light
		LightSlider.value = L_Timer / L_MaxTimer;

	}
	public void MainHealthBar()
	{
		CurrentHealth = (W_Timer + F_Timer)*0.9f ;
		HealthBar.value = CurrentHealth/ MaxHealth;

		if (HealthBar.value <= 0)
		{
			GameplayStartTyphoon = false;
			LoseCollection.SetActive(true);
		}

	}
	public void Stage09WinCondition() // timebase
	{
		//WaterSlider.value = Current_TimerGamePlay / Max_TimerGamePlay;
		Current_TimerGamePlay -= Time.deltaTime;
		
		//ThisWill Happen When it reaches 0 or less than
		if (Current_TimerGamePlay <= 0.005) // Typhoon Done
		{
			Current_TimerGamePlay = 0;
			GameplayStartTyphoon = false;

			if (HealthBar.value > 0)
			{
				//send leaderboard and stuff
				WinCollection.SetActive(true);
				MainScoreStage.AddUpTotalScore();
			}
		}
		else
		{
			TimeBaseFunctions();
		}
	}
	public void ReduceHealthWhenGoOut()
	{
		/*FoodSlider.value -= ReduceDamageWhenOutsideHouse;
		WaterSlider.value -= ReduceDamageWhenOutsideHouse;*/

		F_Timer -= ReduceDamageWhenOutsideHouse;
		W_Timer -= ReduceDamageWhenOutsideHouse;
	}
	public void RelocateItems(GameObject ItemObj)
	{
		int currentIndex = 0; // Initialize a variable to keep track of the current index

		for (int i = 0; i < Item_ParentObjectClass.Length; i++)
		{
			if (Item_ParentObjectClass[currentIndex].transform.childCount == 0) // Use currentIndex to get the current item in the array
			{
				ItemObj.transform.SetParent(Item_ParentObjectClass[currentIndex].transform);
				break; // Exit the loop once an empty GameObject is found
			}
			else
			{
				currentIndex++; // Increment currentIndex to move to the next GameObject in the array
				if (currentIndex == Item_ParentObjectClass.Length) // If we've reached the end of the array, reset currentIndex to zero
				{
					currentIndex = 0;
				}
			}
		}

	}

	//phone messages // rain // pop up message
	public void TimeBaseFunctions() //12 mins of survival
	{
		//
		if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.99f)) //start
		{
			if (anim[0] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 400;
				ReduceDamageWhenOutsideHouse = 0;

				Message.text = "The typhoon is expected to make landfall within the next few hours. Please avoid going outside and seek shelter immediately. ";
				MessagePopUp.SetActive(true);
				Bubble[0].SetActive(true);
				anim[0] = false;
			}

		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.97f)) //11 mins and 36 secs 
		{
			if (anim[1] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 5000;

				ReduceDamageWhenOutsideHouse = 1;
				Message.text = " Power has been interrupted in some areas.";
				MessagePopUp.SetActive(true);
				Bubble[1].SetActive(true);
				anim[1] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.85f)) //11 mins and 36 secs 
		{
			if (anim[2] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 10000;

				ReduceDamageWhenOutsideHouse = 3;
				Message.text = " The typhoon has made landfall and the situation is still unstable. For your safety, please stay indoors and tune in to local news updates for further information. ";
				MessagePopUp.SetActive(true);
				Bubble[2].SetActive(true);
				anim[2] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.7f)) //11 mins and 36 secs 
		{
			if (anim[3] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 10000;
				ReduceDamageWhenOutsideHouse = 3;
				Message.text = "Strong winds and heavy rain are expected";
				MessagePopUp.SetActive(true);
				Bubble[3].SetActive(true);
				anim[3] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.5f)) //11 mins and 36 secs 
		{
			if (anim[4] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 10000;

				Message.text = "The typhoon is still ongoing and the winds are still strong. Please continue to stay indoors and away from windows.";
				ReduceDamageWhenOutsideHouse = 4;
				MessagePopUp.SetActive(true);
				Bubble[4].SetActive(true);
				anim[4] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.25f)) //11 mins and 36 secs 
		{
			if (anim[5] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 1000;
				ReduceDamageWhenOutsideHouse = 2;
				Message.text = "winds are expected to lessen over the next few hours, heavy rain and flooding may still pose a threat.";
				MessagePopUp.SetActive(true);
				Bubble[5].SetActive(true);
				anim[5] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.015f))
		{
			if (anim[6] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 500;
				ReduceDamageWhenOutsideHouse = 1;
				Message.text = "We are pleased to announce that power has been restored to most areas.";
				MessagePopUp.SetActive(true);
				Bubble[6].SetActive(true);
				DarkenColor.color = LighterColor;
				Offlight.SetActive(false);
				OnFlashLight = true;
				LightButton.interactable = false;
				
				//onlights

				anim[6] = false;

			}
		}
		else if (Current_TimerGamePlay >= (Max_TimerGamePlay * 0.01f))
		{
			if (anim[7] == true)
			{
				var emission = Rain.emission;
				emission.rateOverTime = 0;
				ReduceDamageWhenOutsideHouse = 0;
				Message.text = "The typhoon has passed and it is now safe to go outside.";
				MessagePopUp.SetActive(true);
				Bubble[7].SetActive(true);
				DarkenColor.color = LighterColor;
				Offlight.SetActive(false);
				OnFlashLight = true;
				LightButton.interactable = false;
				//GameplayStartTyphoon = false;
				anim[7] = false;

			}
		}


	}


	
}
