using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider bar;
    public Image fill;

    public void SetInitialHealth(float health)
    {
        bar.maxValue = health;
        bar.value = health;
    }

    public void UpdateHealth(float health)
    {
        bar.value = health;
    }
}
