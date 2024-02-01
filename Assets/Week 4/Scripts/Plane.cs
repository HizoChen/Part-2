using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    private float newPositionThreshold;

    private void OnMouseDown()
    {
      lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);
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
}
