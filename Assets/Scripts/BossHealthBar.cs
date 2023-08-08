using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject boss;


    public void SetMaxHealth(int healt)
    {
        slider.maxValue = healt;
        slider.value = healt;
    }

    public void SetHealth(int healt)
    {
        slider.value = healt;
    }
}
