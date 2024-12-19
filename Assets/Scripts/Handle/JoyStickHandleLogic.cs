using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickHandleLogic : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Transform handle;
    private Vector2 pointDownPos;
    public float maxRadius;

    public Vector2 moveInput;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointDownPos = eventData.position;
        //Debug.Log("press");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dis = eventData.position - pointDownPos;
        float clamp = Mathf.Clamp(dis.magnitude, 0, maxRadius);
        Vector2 normal = clamp * dis.normalized;
        handle.localPosition = normal;
        moveInput = normal.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.localPosition = Vector2.zero;
        moveInput = Vector2.zero;
        Debug.Log(moveInput);
    }
}
