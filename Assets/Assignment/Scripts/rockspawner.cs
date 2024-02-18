using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour
{
    public GameObject prefabs;
    float timer = 5;
    float targettime = 5;
    // Start is called before the first frame update
    void Start()
    {

       
       
    }
    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > targettime)
        {
            Instantiate(prefabs);
            timer = 0;
            targettime = Random.Range(1, 5);
        }
        else
        {

        }
    }
}
