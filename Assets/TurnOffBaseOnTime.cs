using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffBaseOnTime : MonoBehaviour
{
	[SerializeField]
	public void Start()
	{
		StartCoroutine(ChangeImageSprite());
	}
	IEnumerator ChangeImageSprite()
	{
		yield return new WaitForSeconds(8f);
		//thisImage.sprite = buttonScript.ItemSprite;
		gameObject.SetActive(false);
		
	}
}
