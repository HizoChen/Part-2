using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector3 speed =new Vector3(-5,0,0);

    // Start is called before the first frame update
    void Start()
    {
       
        rigidbody = GetComponent<Rigidbody2D>();  
       Destroy(gameObject, 5); //disapper in 5 seconds
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position+speed*Time.deltaTime);
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 2, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
