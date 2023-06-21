using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableWhileOnAnim : MonoBehaviour
{
	[SerializeField] GameObject Dialogue;
   public void DialogueHide()
	{
		Dialogue.SetActive(false);
	}
	public void DialogueUnHide()
	{
		Dialogue.SetActive(true);
	}
}
