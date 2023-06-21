using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAdjust : MonoBehaviour
{
	//speedajustment for MN_DropCoverHold
	[SerializeField] bool ApplyThisScript;
	[SerializeField] T3_DropCoverHold_AnimationAndController DCHManager;
    public void MN()
	{
		if (ApplyThisScript)
		{
			DCHManager.MNAdjusmentMovementSpeed();
		}
		
	}

	public void MainPlayer()
	{
		if (ApplyThisScript)
		{
			DCHManager.AdjusmentMovementSpeed();

		}
	}

}
