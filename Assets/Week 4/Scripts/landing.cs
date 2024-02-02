using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class landing : MonoBehaviour
{
    public GameObject plane;
    public bool inlanding;
    public int score;
    Collider2D runway;
    // Start is called before the first frame update
    void Start()
    {
        runway = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (runway.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.gameObject.GetComponent<Plane>().inlanding = true;
            score++;
        }
       }
}

