using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPaperObj : MonoBehaviour
{
	[SerializeField] Canvas HiddenObjectCanvas;
	//[SerializeField] GameObject[] InfoClassOfHiddenObj;
	[SerializeField] GameObject[] ClassesTittle;
	[SerializeField] GameObject[] LayoutClasses;
	[SerializeField] GameObject[] ClassOnBoard;




	public void FoundObject(GameObject ObjectFound)
	{
		HiddenObjectCanvas.enabled = true;
		ObjectFound.SetActive(false);
		
	}

	public void ClassesFound(GameObject ClassLetter)
	{
		ClassLetter.SetActive(true);
	}

	public void OnExit()
	{
		HiddenObjectCanvas.enabled = false;
		foreach (GameObject obj in LayoutClasses)
		{
			obj.SetActive(false);
			
		}
		DeactivateClassOnExit();
	}

	public void DeactivateClassOnExit()
	{
		foreach(GameObject obj in ClassesTittle)
		{
			obj.SetActive(false);
		}
		
	}

	public void ActivateLetter(GameObject LetterClassOnBoard)
	{
		LetterClassOnBoard.SetActive(true);
	}



}
