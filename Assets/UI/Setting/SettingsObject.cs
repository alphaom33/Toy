using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "settings", menuName = "settings")]
public class SettingsObject : ScriptableObject
{
    public float mouseSensitivity = 1;
    public float volume;
}
