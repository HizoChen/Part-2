using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        slider.value -= damage;

    }
}