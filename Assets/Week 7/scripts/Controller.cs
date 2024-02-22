using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider chargeslider;
    float chargeValue;
    public float chargeMax = 1;
    Vector2 direction;
    public static selection selectedPlayer { get; private set; }
    public static void SetselectedPlayer(selection player)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
        }
        selectedPlayer = player;
        selectedPlayer.Selected(true);
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero) 
        {
            selectedPlayer.Movement(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            chargeslider.value = chargeValue;
        }
    }
    private void Update()
    {
        if (selectedPlayer == null) return;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
        direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, chargeMax);
            chargeslider.value = chargeValue;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
         direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)-(Vector2)selectedPlayer.transform.position).normalized*chargeValue;

        }

    }
}
