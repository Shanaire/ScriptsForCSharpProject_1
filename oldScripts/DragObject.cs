using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("--Being Dragged--");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("--while Dragged--");
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("--end Dragged--");
    }
}
