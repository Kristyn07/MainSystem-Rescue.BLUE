using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 defaultPosition;
	private void Start()
	{
		defaultPosition = transform.position;
	}

	public void ResetPos()
	{
		transform.position = defaultPosition;
	}
}
