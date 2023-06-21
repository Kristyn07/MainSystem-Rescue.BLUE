using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace DragDrop
{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas canvas;
        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        public GameObject ActiveItem;
        public GameObject objStation;
        private BoxCollider2D bc;
        Vector3 originalPos;

        private void Awake()
        {
            originalPos = new Vector3(0, 0, 0);
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            rectTransform.anchoredPosition = originalPos;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }


    }
}
