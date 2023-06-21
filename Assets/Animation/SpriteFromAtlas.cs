using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteFromAtlas : MonoBehaviour
{
	[SerializeField] SpriteAtlas Atlas;
	[SerializeField] string SpriteName;

	void Start()
	{
		GetComponent<Image>().sprite = Atlas.GetSprite(SpriteName);
	}
}
