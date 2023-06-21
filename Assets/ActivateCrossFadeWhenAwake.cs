using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrossFadeWhenAwake : MonoBehaviour
{
    [SerializeField] GameObject CrossFradeTransition;

	public void Awake()
	{
		CrossFradeTransition.SetActive(true);
	}
}
