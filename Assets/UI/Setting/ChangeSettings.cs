using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour
{
    public SettingsObject settings;
    private Slider sensitivity;
    private Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity = GetComponentsInChildren<Slider>()[0];
        volume = GetComponentsInChildren<Slider>()[1];
    }

    // Update is called once per frame
    void Update()
    {
       settings.mouseSensitivity = sensitivity.value;
        settings.volume = volume.value;
    }
}
