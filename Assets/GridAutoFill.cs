using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridAutoFill : MonoBehaviour
{
	[SerializeField] GridFillerColliders[] _gridFillerColliders;
	[SerializeField] float DelaySec;
	[SerializeField] Sprite FilledGridSprite;
	[SerializeField] GridSlots slots;

	private void Start()
	{
		GridIsFilled();
	}
	public void GridIsFilled()
	{
		foreach(GridFillerColliders gridfiller in _gridFillerColliders)
		{
			gridfiller.isFilled = true;
		}
		for (int i = 0; i < slots.colliders.Count; i++)
		{
			slots.colliders[i].GetComponent<Image>().sprite = FilledGridSprite;
			slots.colliders[i].GetComponent<Image>().color = new Color(255, 255, 255, 255f);
		}
	}
}
