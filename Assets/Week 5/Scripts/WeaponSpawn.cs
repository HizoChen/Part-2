using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject prefabs;
    // Start is called before the first frame update
    public void Spawn()
    {
        Instantiate(prefabs);
    }
}
