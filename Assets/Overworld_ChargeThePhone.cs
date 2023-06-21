using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_ChargeThePhone : MonoBehaviour
{
	
	[SerializeField] GameObject NotChargeGO;
	[SerializeField] GameObject ChargingGO;

	[Header("Fan")]
	[SerializeField] bool Stage9;
	[SerializeField] TaskCompleteCargingPhone _removephone;
	[SerializeField] TaskCompletePlugOnly _OneplugOnly;
	[SerializeField] CableConnector _oneplugButton;
	[SerializeField] Animator UIFan;

	/*[Header("TV")]
	[SerializeField] GameObject.se*/
	public void PhoneIsCharge()
	{
		if (ChargingGO != null)
		{
			ChargingGO.SetActive(true);
		}
		
			
		if (NotChargeGO != null)
		{
			NotChargeGO.SetActive(false);
		}
	}

	public void PhoneIsNotCharge()
	{
		if (NotChargeGO != null) 
		{
			NotChargeGO.SetActive(true);
		}
		if (ChargingGO != null)
		{
			ChargingGO.SetActive(false);
		}
		
	}


	//centralize Stage09

	public void RemovePhoneOnCharge()
	{
		if (_removephone.TaskIsDone == false)
		{
			PhoneIsCharge();
		}
	}

	public void RemoveOnePlug(Animator anim)
	{
		if (_OneplugOnly.TaskIsDone == false)
		{
			PhoneIsCharge();
			UIFan.SetBool("ON", false);
		}

		else
		{
			if (_oneplugButton.IsConnected)
			{
				anim.enabled = true;
				UIFan.enabled = true;
				
			}
			else
			{
				anim.enabled = false;
				UIFan.enabled = false;
				
			}
		}
	}//fan

	public void TVManipulation()
	{
		
	}

}
