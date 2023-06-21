using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonIsPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool ButtonPressed;
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        ButtonPressed = true;
       
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        ButtonPressed = false;
    }
}
