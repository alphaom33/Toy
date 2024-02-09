using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField] public SettingsObject settingsObject;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("SettingsController"))
        {
            DontDestroyOnLoad(gameObject);
        }        
    }

    private void Update()
    {
        const string audioSettingsAssetPath = "ProjectSettings/AudioManager.asset";
        SerializedObject audioManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(audioSettingsAssetPath)[0]);

        SerializedProperty volume = audioManager.FindProperty("m_Volume");
        volume.floatValue = settingsObject.volume;

        audioManager.ApplyModifiedProperties();
        Debug.Log(audioManager.FindProperty("m_Volume").floatValue);
    }

}
