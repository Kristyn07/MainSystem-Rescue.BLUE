using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharDialogueManager : MonoBehaviour
{
	public Text DialogueText;

	public Animator animator;

	private Queue<string> sentences;

	[SerializeField] int dialoguecount = 0;
	[Header("SetActive Object")]
	[SerializeField] GameObject[] SetActiveObj;
	[Header("Body Tour")]
	[SerializeField] GameObject[] BodyObj;
	[Header("TapToContinueBTN")]
	[SerializeField] GameObject TaptoContinue;
	[Header("HandAnim")]
	[SerializeField] GameObject HandTap;
	[Header("Randomize tour")]
	[SerializeField] GameObject[] obj;
	[Header("Select tour")]
	[SerializeField] GameObject[] SelectObj;
	[Header("Return tour")]
	[SerializeField] GameObject[] Returnobj;

	//[Header("CharacterCustomization Explained")]
	//[SerializeField] GameObject BTN;


	void Start()
	{

		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue _dialogue)
	{

		Debug.Log("The dialog is starting");
		animator.SetBool("IsOpen", true);
		sentences.Clear();

		foreach (string sentence in _dialogue.sentences)
		{

			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
		dialoguecount = 1; // intro dialogue
	}

	public void DisplayNextSentence()
	{
		dialoguecount++;

		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		Debug.Log(sentence);
		//DialogueText.text= sentence;
		SetActiveButtons();
		StopAllCoroutines();

		if (PlayerPrefs.GetInt("AnimatedTextToggle") == 1)
		{
			StartCoroutine(TypeSentence(sentence));
		}
		else
		{
			DialogueText.text = sentence;

		}	
	}

	IEnumerator TypeSentence(string sentence)
	{
		DialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			DialogueText.text += letter;
			yield return null;
		}
	}
	void EndDialogue()
	{
		Debug.Log("End of Conversation");
		animator.SetBool("IsOpen", false);
	}

	public void SetActiveButtons()
	{
		int x = dialoguecount;

		switch (x)
		{
			case 1:
				Debug.Log("Intro");
				break;
			case 2:
				Debug.Log("Body");
				SetActiveObj[0].SetActive(true);
				break;
			case 3:
				Debug.Log("Select Btnpart");
				BodyObj[0].SetActive(true);
				HandTap.SetActive(false);
				break;
			case 4:
				Debug.Log("Prevous next button");
				BodyObj[1].SetActive(true);
				HandTap.SetActive(true);
				TaptoContinue.SetActive(false);
				break;
			case 5:
				Debug.Log("Random");
				HandTap.SetActive(false);
				SetActiveObj[0].SetActive(false);
				BodyObj[0].SetActive(false);
				BodyObj[1].SetActive(false);
				BodyObj[2].SetActive(false); 
				obj[0].SetActive(true);
				obj[1].SetActive(true);
				obj[2].SetActive(true);
				break;
			case 6:
				obj[0].SetActive(false);
				obj[1].SetActive(false);
				obj[2].SetActive(false);
				SelectObj[0].SetActive(true);
				SelectObj[1].SetActive(true);
				SelectObj[2].SetActive(true);
				TaptoContinue.SetActive(false);
				break;
			case 7:
				
				SelectObj[0].SetActive(false);
				SelectObj[1].SetActive(false);
				SelectObj[2].SetActive(false);
				TaptoContinue.SetActive(false);
				Returnobj[0].SetActive(true);
				break;
			


		}


	}

	
	public void ResetDialogCount()
	{
		dialoguecount = 0;
	}
}


