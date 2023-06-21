using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [Header("MainMenuDialogue")]
	public Dialogue dialogue;
	[Header("ChasCustDialogue")]
	public Dialogue _dialogue;
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
	public void TriggerDialogChar()
	{
		FindObjectOfType<CharDialogueManager>().StartDialogue(_dialogue);
	}
}
