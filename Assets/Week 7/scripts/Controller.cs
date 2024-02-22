using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
 
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
}
