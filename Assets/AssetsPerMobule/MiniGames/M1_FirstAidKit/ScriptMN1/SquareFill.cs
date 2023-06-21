using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class SquareFill : MonoBehaviour, IDropHandler
    {
        public bool isFiller;
        public bool isFilled;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.transform.position;
            isFilled = true;
        }
    }
}