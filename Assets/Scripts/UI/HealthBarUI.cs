using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider mSlider;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        // Inscribirnos como observadores del PlayerDamage
        GameManager.Instance.OnPlayerDamage += OnPlayerDamageDelegate; 
    }

    private void OnPlayerDamageDelegate(object sender, EventArgs e)
    {
        mSlider.value -= 1f;
    }
}
