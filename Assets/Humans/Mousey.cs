using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.XR;


public class Mousey : MonoBehaviour
{
    public bool doIt = true;
    [SerializeField] InputAction turnAction;

    private void OnEnable()
    {
        turnAction.Enable();
    }
    private void OnDisable()
    {

        turnAction.Disable();
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (doIt)
            MoveMouseInfinitely();
    }

    public void MoveMouseInfinitely()
    {
        float mouseXpos = turnAction.ReadValue<Vector2>().x;
        float mouseYpos = turnAction.ReadValue<Vector2>().y;

        if (mouseXpos >= Screen.width)
        {
            Debug.Log(mouseXpos);
            Mouse.current.WarpCursorPosition(new Vector2(10, mouseYpos));
        }
        else if (mouseXpos <= 0)
        {
            Mouse.current.WarpCursorPosition(new Vector2(Screen.width - 10, mouseYpos));
        }

        if (mouseYpos >= Screen.height)
        {
            Debug.Log(mouseXpos);
            Mouse.current.WarpCursorPosition(new Vector2(mouseXpos, 10));
        }
        else if (mouseYpos <= 0)
        {
            Mouse.current.WarpCursorPosition(new Vector2(mouseXpos, Screen.height - 10));
        }
    }
}