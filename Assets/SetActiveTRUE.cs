using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTRUE : MonoBehaviour
{
	[SerializeField] GameObject Obj;
    void SetTRUE()
	{
		Obj.SetActive(true);
	}
}
