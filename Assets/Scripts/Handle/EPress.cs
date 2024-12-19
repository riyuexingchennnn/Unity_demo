using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPress;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPress = true;
        //Debug.Log("press");
    }

    

    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
    }
}
