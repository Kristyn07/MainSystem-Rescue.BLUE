using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainmenuCharacterHandling : MonoBehaviour
{
    [Header("IsCustomizong")]
	public Animator animator;
    public GameObject obj;

	[Header("IsCSelectingCharacter")]
	public Animator animation_Selection;
	public GameObject SelectionChar;

	
	//CharinMainMenu or Char Animation
	public void CharInMAinMenu()
	{
		animator.SetBool("isCustomizing", false);
	}
	public void CharAnimation()
	{		
		animator.SetBool("isCustomizing", true);
				
	}


	//Player is Selecting or Isndividual Body Parts
	public void IsInBodyCustom()
	{
		animation_Selection.SetBool("isCustomizingBodyParts", true);
	}
	public void IsInSelectionCustom()
	{
		animation_Selection.SetBool("isCustomizingBodyParts", false);

	}
}
