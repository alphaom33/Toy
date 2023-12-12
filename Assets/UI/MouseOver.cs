using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CursorController cursor;

    private void Start()
    {
        cursor = GameObject.FindWithTag("Cursor").GetComponent<CursorController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.visible = true;
        cursor.gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.visible = false;
        cursor.gameObject.SetActive(true);
    }
}
