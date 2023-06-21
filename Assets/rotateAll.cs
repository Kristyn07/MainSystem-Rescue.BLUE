using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAll : MonoBehaviour
{
    [SerializeField] RotateItem[] rotateall;


    void RotateAllItem()
	{



		foreach (RotateItem rotate in rotateall)
		{
			//rotate.rotateSprite();
		}
	}

}
