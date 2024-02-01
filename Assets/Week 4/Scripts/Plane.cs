using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    private float newPositionThreshold;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Color mycolor;
    float distanceapart;
    float distance;
    Collider2D other;




    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(1,4)]; 
      lineRenderer = GetComponent<LineRenderer>();
        speed = Random.Range(1, 3);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position + new Vector3(Random.Range(-5f,5f),0));
        GetComponent<Transform>().rotation = Quaternion.Euler(0f,0f,Random.Range(0,360));
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer.color = mycolor;
       
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    private void Update()
    {
        
    
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation =landing.Evaluate(landingTimer);
            if ((transform.localScale.z < 0.1f))
            {
                Destroy(gameObject);
            }
            transform . localScale = Vector3.Lerp(Vector3.one,Vector3.zero,interpolation);
        }
        lineRenderer.SetPosition(0, transform.position);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            Destroy(gameObject);
        }
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < pointThreshold) 
            {
                points.RemoveAt(0);

                for (int i = 0; i< lineRenderer.positionCount - 2; i++) 
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }
    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag() 
    {
     Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount-1,newPosition);
            lastPosition = newPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
        distanceapart = 1.2f;
        distance = Vector3.Distance(transform.position, collision.gameObject.transform.position);
        if (distanceapart >= distance)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = mycolor;
    }
}
