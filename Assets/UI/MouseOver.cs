using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseOver : MonoBehaviour, IPointerExitHandler
{
    private GameObject cursorC;
    private bool stupid;
    private Mousey mousey;

    private void Start()
    {
        cursorC = GameObject.FindWithTag("Cursor");
        mousey = GameObject.FindWithTag("Mousey").GetComponent<Mousey>();
        stupid = false;
    }
    private void Update()
    {
        Vector3 cursorPos = Camera.main.WorldToScreenPoint(cursorC.transform.position);
        if (!stupid && cursorC.activeInHierarchy && cursorPos.x < 100)
        {
            cursorPos.x = 90;
            Debug.Log("hasdjkfsjsadk");
            mousey.doIt = false;
            Mouse.current.WarpCursorPosition(cursorPos);
            cursorC.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        stupid = true;
        cursorC.SetActive(true);
        cursorC.GetComponent<CursorMove>().mousePos.x = 115;
        Cursor.visible = false;
        mousey.doIt = true;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        stupid = false;
    }
}
