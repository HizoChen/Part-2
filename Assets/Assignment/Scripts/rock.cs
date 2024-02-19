using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor.Experimental.GraphView;

public class rock : MonoBehaviour
{
    public AnimationCurve dropping;
    Rigidbody2D rigidbody;
    Vector3 speed = new Vector3(0, -5, 0);
    float droppingTimer;
    public bool indropping;
    

    // Start is called before the first frame update
    void Start()
    {
        indropping = true;
        rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
        transform.Translate(transform.position+ new Vector3(Random.Range(-8f, 8f), 5,0));
    }
    private void FixedUpdate()
    {
        if (indropping)
        {
            droppingTimer += 0.5f * Time.deltaTime;
            rigidbody.MovePosition(transform.position + speed * Time.deltaTime);
            float interpolation = dropping.Evaluate(droppingTimer);
            transform.localScale = Vector3.Lerp(Vector3.one * 5.32f, Vector3.one * 10f, interpolation);
        }
    }
    private void Update()
    {
         Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 2, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
