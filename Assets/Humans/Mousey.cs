using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;


public class Mousey : MonoBehaviour
{
    public bool doIt = true;
    public bool queued = true;

    public SettingsObject settings;

    [Header("Mouse")]
    [SerializeField] InputAction turnAction;
    public Vector2 mousePos;
    public float mouseSpeed;


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
        WindowHandler.Init();
        Cursor.visible = false;
    }

    void Update()
    {
        mouseSpeed = settings.mouseSensitivity;
        if (WindowHandler.IsFocus())
        {
            DoMouseStuff();
        }
        if (Input.GetKeyDown(KeyCode.Q))
            queued = !queued;
    }

    private void DoMouseStuff()
    {
        mousePos += new Vector2(turnAction.ReadValue<Vector2>().x, turnAction.ReadValue<Vector2>().y);

        if (doIt && queued)
        {
            mousePos = MoveMouseInfinitely();
//            Debug.Log("ajsk");
        }
        Mouse.current.WarpCursorPosition(mousePos * mouseSpeed);
    }

    public Vector2 MoveMouseInfinitely()
    {
        Vector2 changeVector = mousePos;
        if (mousePos.x >= Screen.width)
        {
            changeVector.x = 10;
        }
        else if (mousePos.x <= 0)
        {
            changeVector.x = Screen.width - 10;
        }

        if (mousePos.y >= Screen.height)
        {
            changeVector.y = 10;
        }
        else if (mousePos.y <= 0)
        {
            changeVector.y = Screen.height - 10;
        }
        
        return changeVector;
    }
}
