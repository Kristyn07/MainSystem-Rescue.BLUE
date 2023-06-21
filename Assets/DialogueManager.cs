using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text DialogueText;

	public Animator animator;

	private Queue<string> sentences;

	[SerializeField] int dialoguecount = 0;
	[Header("SetActive Object")]
	[SerializeField] GameObject[] SetActiveObj;
	[Header("TapToContinueBTN")]
	[SerializeField] GameObject TaptoContinue;
	[SerializeField] GameObject HandTap;
	[Header("CharacterCustomization Explained")]
	[SerializeField] GameObject BTN;
	//[SerializeField] GameObject AccountBTN; 

	void Start()
	{

		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{

		Debug.Log("The dialog is starting");
		animator.SetBool("IsOpen", true);
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
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
		//Debug.Log(sentence);
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
		//AccountBTN.SetActive(true);
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
				Debug.Log("Continue");
				SetActiveObj[0].SetActive(true);
				break;
			case 3:
				Debug.Log("Start");
				SetActiveObj[0].SetActive(false);
				SetActiveObj[1].SetActive(true);
				break;
			case 4:
				Debug.Log("Stage Selection");
				SetActiveObj[1].SetActive(false);
				SetActiveObj[2].SetActive(true);
				break;
			case 5:
				Debug.Log("ExitButton");
				SetActiveObj[2].SetActive(false);
				SetActiveObj[3].SetActive(true);
				break;
			case 6:
				Debug.Log("LeaderBoard");
				SetActiveObj[3].SetActive(false);
				SetActiveObj[4].SetActive(true);
				break;
			case 7:
				Debug.Log("Options");
				SetActiveObj[4].SetActive(false);
				SetActiveObj[5].SetActive(true);
				break;
			case 8:
				SetActiveObj[5].SetActive(false);
				SetActiveObj[6].SetActive(true);
				Debug.Log("Character");
				break;
			case 9:
				Debug.Log("charactercustomization");
				TaptoContinue.SetActive(false);
				Tap();
				BTN.SetActive(true);
				break;


		}


	}

	public void Tap()
	{
		HandTap.SetActive(true);
	}

	public void ResetDialogCount()
	{
		dialoguecount = 0;
	}
}


