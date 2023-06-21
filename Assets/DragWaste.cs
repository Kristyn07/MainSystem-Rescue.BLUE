using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWaste : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalPosition;
    private CheckWasteIfIsInTheRightTrashBin _checkWasteIfIsInTheRightTrashBin;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
        _checkWasteIfIsInTheRightTrashBin = GetComponent<CheckWasteIfIsInTheRightTrashBin>();
        //trashBinChecker = FindObjectOfType<CheckWasteIfIsInTheRightTrashBin>();
    }



    public void OnDrag(PointerEventData eventData)
    {
        _checkWasteIfIsInTheRightTrashBin.ThisWasteCol.enabled = true;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition = originalPosition;
        if (_checkWasteIfIsInTheRightTrashBin.Checker == true)
		{
            _checkWasteIfIsInTheRightTrashBin.DoThisOnDrop();
        }
		else
		{
            _checkWasteIfIsInTheRightTrashBin.DothisOnDropWrong();
            rectTransform.anchoredPosition = originalPosition;
        }
    }


}
