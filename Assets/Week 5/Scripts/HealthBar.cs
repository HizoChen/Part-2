using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   
    public Slider slider;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    { 
        slider.value -= damage;

    }
        void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float health)
    {
        slider.value = health;

    }
}
