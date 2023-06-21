using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stage080910;
public class ElectricFanUIManipulation : MonoBehaviour
{
    
    [SerializeField] Animator ElectricFanAnimation;
	
	public void ElectricFanisOn()
	{
            ElectricFanAnimation.SetBool("ON",true);
    }

	public void ElectricFanisOff()
	{
		ElectricFanAnimation.SetBool("ON", false);
	}
}
