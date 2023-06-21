using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimAutoNextClip : MonoBehaviour
{
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}
	public void TriggerSetTrue(string BoolAnim)
	{
		//after animation do this 
		anim.SetBool(BoolAnim , true);
	}
	

	public void TriggerSetFalse(string BoolAnim)
	{
		//after animation do this 
		anim.SetBool(BoolAnim, false);
	}
	
	public void ChangeIntToZero(string IntNum)
	{
		anim.SetInteger(IntNum, 0);
	}

}
