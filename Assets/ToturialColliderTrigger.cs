using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ToturialColliderTrigger : MonoBehaviour
{
	[Header("Collided = True")]
	public bool TargetLeftArea;
	public bool TargetRightArea;
	public bool TargetSeenGuide;
	public bool TargetPopUpGuideArea;
	public bool TargetMiniGameArea;

	public bool MiniGameIsDone;

	[Header("BoxCollider")]
	[SerializeField] BoxCollider2D LeftArea;
	[SerializeField] BoxCollider2D RightArea;
	[SerializeField] BoxCollider2D PopUpGuideArea;
	[SerializeField] BoxCollider2D MiniGameArea;
	[SerializeField] BoxCollider2D SeenPopUpMark;

	[SerializeField] Rigidbody2D player;
	[SerializeField] BoxCollider2D Player;

	[Header("Collided Target")]
	//[SerializeField] ToturialColliderTrigger _toturialColliderTrigger;
	public Animator FadeLeftArea;
	public Animator FadeRightArea;
	public Animator FadePopUpGuideArea;
	public Animator FadeMiniGame;

	[Header("Tap To Continue BTN")]
	[SerializeField] GameObject tapToContinueDialog;

	[Header("Hand")]
	[SerializeField] GameObject LeftControlTapHand;
	[SerializeField] GameObject RightControlTapHand;
	[SerializeField] GameObject InspectControlTapHand;

	[Header("Button Trigger")]
	[SerializeField] GameObject LeftControlTapTrigger;
	[SerializeField] GameObject RightControlTapTrigger;
	[SerializeField] GameObject InspectControlTapTrigger;

	[Header("CameraFollow")]
	[SerializeField] Stage1CameraFollow _stage1CameraFollow;

	[Header("AutomaicContinue")]
	[SerializeField] DialogManager_Toturial _dialogManager_Toturial;
	private void Start()
	{
		
		/*TargetLeftArea = false;
		TargetRightArea = false;
		TargetPopUpGuideArea = false;
		TargetMiniGameArea = false;
		TargetSeenGuide = false;
		MiniGameIsDone = false;*/
		/*FadeLeftArea.SetBool("IsFading", false);
		FadeRightArea.SetBool("IsFading", false);
		FadePopUpGuideArea.SetBool("IsFading", false);*/

		/*FadeLeftArea.enabled = false;
		FadeRightArea.enabled = false;
		FadePopUpGuideArea.enabled = false;*/
	}


	void OnTriggerEnter2D(Collider2D Player)
	{
		


		if (Player == LeftArea)
		{
			//FadeLeftArea.enabled = true;
			TargetLeftArea = true;
			FadeLeftArea.SetBool("IsFading", true);
			Debug.Log("Collided to left area");
			tapToContinueDialog.SetActive(true);
			LeftControlTapHand.SetActive(false);
			LeftArea.GetComponent<Collider2D>().enabled = false;
			LeftControlTapTrigger.SetActive(false);
			_dialogManager_Toturial.DisplayNextSentence();

		}
		
		if (Player == RightArea)
		{

			//FadeRightArea.enabled = true;
			FadeRightArea.SetBool("IsFading", true);
			TargetRightArea = true;
			Debug.Log("Collided to left area");
			tapToContinueDialog.SetActive(true);
			RightControlTapHand.SetActive(false);
			RightArea.GetComponent<Collider2D>().enabled = false;
			//_dialogManager_Toturial.DisplayNextSentence();
			_dialogManager_Toturial.DisplayNextSentence();
		}
		if (Player == SeenPopUpMark)
		{
			//FadePopUpGuideArea.SetBool("IsFading", false);
			TargetSeenGuide = true;
			//FadePopUpGuideArea.SetBool("IsFading", false);
			//TargetPopUpGuideArea = false;
			Debug.Log("Collided to seen area");
			tapToContinueDialog.SetActive(true);
			SeenPopUpMark.GetComponent<Collider2D>().enabled = false;
			_dialogManager_Toturial.DisplayNextSentence();
		}
		if (Player == PopUpGuideArea)
		{
			//FadePopUpGuideArea.enabled = true;
			FadePopUpGuideArea.SetBool("IsFading", true);
			TargetPopUpGuideArea = true;
			Debug.Log("Collided to guide area");
			tapToContinueDialog.SetActive(true);
			PopUpGuideArea.GetComponent<Collider2D>().enabled = false;
			_dialogManager_Toturial.DisplayNextSentence();
		}

		if (MiniGameIsDone == false) {
			if (Player == MiniGameArea)
			{
				//FadeMiniGame.SetBool("IsFading", true);
				TargetMiniGameArea = true;
				Debug.Log("Enter Collided to minigame area");
				//tapToContinueDialog.SetActive(true);
				//MiniGameArea.GetComponent<Collider2D>().enabled = false;
				//InspectControlTapHand.SetActive(false);
				InspectControlTapTrigger.SetActive(true);
				//InspectControlTapTrigger.gameObject.SetActive(true);
				InspectControlTapHand.SetActive(true);

			} 
		}
		
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (MiniGameIsDone == false)
		{
			if (Player == MiniGameArea)
			{
				Debug.Log("stay");
				InspectControlTapTrigger.gameObject.SetActive(true);
				InspectControlTapHand.SetActive(true);
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
			InspectControlTapTrigger.SetActive(false);
			Debug.Log("exit");
			InspectControlTapHand.SetActive(false);

			

	}


	void AutoNextSentence()
	{
		if (SeenPopUpMark == true)
		{
			_dialogManager_Toturial.DisplayNextSentence();
		}
	}
}