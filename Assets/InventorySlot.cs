using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
	
	
	public void OnDrop(PointerEventData eventData)
	{
		
		if (transform.childCount == 0) {
			GameObject dropped = eventData.pointerDrag;
			DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
			draggableItem.parentAfterDrag = transform;

		}
		else if (transform.childCount == 1)//swapping
		{
			var child = this.gameObject.transform.GetChild(0);
			DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
			child.SetParent(draggableItem.parentAfterDrag);
			draggableItem.parentAfterDrag = transform;
		}
	}
	
}
 