using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger_Toturial : MonoBehaviour
{
	[Header("Dialogue")]
	public Dialog_GamePlay dialogue; // reusable script
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogManager_Toturial>().StartDialogue(dialogue);
	}
}
