using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenClicked : MonoBehaviour
{
    public void DestroyInstantiatedRank()
	{
		Destroy(gameObject);
	}
}
