using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger_GamePlay : MonoBehaviour
{
	[Header("Dialogue")]
	public Dialog_GamePlay dialogue;
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogManager_GamePlay>().StartDialogue(dialogue);
	}
}
