using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resolution : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change169()
    {
        Screen.SetResolution(1600, 900, false); 
    }
    public void ChangeFull()
    {
        Screen.SetResolution(1920, 1080,false);
    }
}
