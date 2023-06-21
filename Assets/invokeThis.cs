using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Centralize.Button;
public class invokeThis : MonoBehaviour
{
	[SerializeField] CentralizeAccountBTN thisScript;

	public void Function()
	{
		Invoke("InovkeThiScriptForSomeReason", 3f);
	}
	public void InovkeThiScriptForSomeReason()
	{
		thisScript.AccountButton();
	}
}
