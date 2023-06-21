using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTyphoonCallScript : MonoBehaviour
{
	[SerializeField] StartGameTyphoon _start;

	public void DothisWhenComplete()
	{
		StartCoroutine(_start.OrderExecution());
	}
}
