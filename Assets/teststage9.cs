using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teststage9 : MonoBehaviour
{
    [SerializeField] ButtonScript[] _button;

    public void TestInventory()
	{
		foreach(ButtonScript test in _button)
		{
			test.InverntorySystem();
		}
	}
}
