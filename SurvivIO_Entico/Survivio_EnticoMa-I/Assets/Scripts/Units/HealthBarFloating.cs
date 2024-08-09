using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFloating : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public void UpdateHP(float currHP, float maxHP)
    {
        slider.value = currHP / maxHP;
    }
}
