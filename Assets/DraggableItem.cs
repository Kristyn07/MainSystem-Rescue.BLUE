using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[HideInInspector] public Transform parentAfterDrag;
	public Image image;
	float alpha = 0.8f;
	[SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrop;

	public void OnBeginDrag(PointerEventData eventData)
	{
		parentAfterDrag = transform.parent;
		transform.SetParent(transform.root);
		transform.SetAsLastSibling();
		image.raycastTarget = false;
	}
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
		/*Color tempColor = image.color;
		tempColor.a = alpha;
		image.color = tempColor;*/
		
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(parentAfterDrag);
		image.raycastTarget = true;
		_extinguisherClassesDragAndDrop.CheckTheLoc();
	}

	public void CheckLocation()
	{

	}
}
