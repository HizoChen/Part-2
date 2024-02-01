using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
  
    public GameObject prefabs;
    float timer = 0;
    float targettime = 5;

    void Start()
    {
        int prefab = Random.Range(0, 4);
        InvokeRepeating("Spawn", 2.0f, 2.0f);

    }

    void Update()
    {
        timer= timer + Time.deltaTime;
     if(timer > targettime)
        {
            Instantiate(prefabs);
            timer= 0;
            targettime = Random.Range(1,5);
        }
        else
        {

        }


    }
   
   
}
