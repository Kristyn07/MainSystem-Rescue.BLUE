using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTheAnswer : MonoBehaviour
{
    public GameObject[] Choices;
    public Button[] ChoicesBtn;
    public bool[] CheckAnswer;
    public bool injurydetected = false;
	public Image[] ChoicesImage;
	public GameObject[] deact;

	[SerializeField]
	GameObject CoverButton;
	[SerializeField] PanZoom panZoom;
	[SerializeField] Image MainDummy;
	//[SerializeField] GameObject MainDummyObj;
	[SerializeField] GameObject[] WrongChoices;
	[SerializeField] GameObject[] RightChoiceObj;

	
    public void RightAnswer()
	{
		Debug.Log("Injury Detected");
        injurydetected = true;
		Invoke("CorrectAnswer",1.5f);
		
	}

	public void WrongAnswer1()
	{
		Debug.Log("Oh no Unable to detect injury");
		ChoicesBtn[1].interactable = false;
		ChoicesImage[1].color = Color.gray;
		StartCoroutine(EnableButtonCover());
		
	}
	public void WrongAnswer2()
	{
		
		Debug.Log("Oh no Unable to detect injury");
		ChoicesBtn[2].interactable = false;
		ChoicesImage[2].color = Color.gray;
		StartCoroutine(EnableButtonCover());
	}

	IEnumerator EnableButtonCover()
    {
		CoverButton.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		CoverButton.gameObject.SetActive(false);
		panZoom.ZoomOut();
		MainDummy.enabled = true;
		//MainDummyObj.SetActive(true);
		foreach (GameObject obj in WrongChoices)
		{
			obj.SetActive(false);
		}
	}

	void CorrectAnswer()
	{
		foreach (GameObject obj in deact)
		{
			obj.SetActive(false);
		}
		foreach (GameObject obj in RightChoiceObj)
		{
			obj.SetActive(true);
		}
	}

}
