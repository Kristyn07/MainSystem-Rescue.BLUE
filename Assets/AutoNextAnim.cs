using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoNextAnim : MonoBehaviour
{
	[SerializeField] Animator Anim;
	public void OnDropToIdle()
	{
		Anim.SetBool("Drop", true);
	}

	public void OnStand()
	{
		Anim.SetBool("Stand", true);
	}
}