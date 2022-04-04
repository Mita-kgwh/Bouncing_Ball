using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //public UnityEvent<int> eventInt;
    public UnityEvent eventMouseDown; 
    public UnityEvent eventMouseUp;
    //public Event eventMouseDown2;

    public void OnPointerDown(PointerEventData eventData)
    {
        eventMouseDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        eventMouseUp.Invoke();
    }
}
