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
    Rigidbody2D rb;
    public float speed = 900;
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);             
    }
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Controller.SetselectedPlayer(this);

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
    public void Movement(Vector2 direction) 
    {
        rb.AddForce(direction*speed);
    }
}
