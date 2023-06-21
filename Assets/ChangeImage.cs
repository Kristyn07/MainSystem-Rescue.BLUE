using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour
{
    [SerializeField] ButtonScript buttonScript;
	//[SerializeField] GameObject MainOBject;
	private Image thisImage;
	public void Start()
	{
		//MainOBject = buttonScript.gameObject;
		thisImage = GetComponent<Image>();
		StartCoroutine(ChangeImageSprite());
	}

	IEnumerator ChangeImageSprite()
	{
		yield return new WaitForSeconds(4.9f);
		thisImage.sprite = buttonScript.ItemSprite;
		//MainOBject.SetActive(false);
		thisImage.SetNativeSize();
	}
}
