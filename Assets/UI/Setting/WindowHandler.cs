using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class WindowHandler
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    [DllImport("User32.Dll")]  
    private static extern IntPtr GetFocus();
#endif

    private static IntPtr thisWindow;
    public static bool onThisWindow;

    // Start is called before the first frame update
    public static void Init()
    {
        thisWindow = GetFocus();
    }

    // Update is called once per frame
    public static bool IsFocus()
    {
        return thisWindow == GetFocus();
    }
}
