using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{
   
    public Color oldcolor;
    public Color newcolor;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Selected(true);
    }
    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            spriteRenderer.color = newcolor;
        }
        else
        {
            spriteRenderer.color = oldcolor;
        }

    }
}
