using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Yeti : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 movement;
    Vector2 destination=new Vector2(0, -3.93f);
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    public HealthBar healthBar;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        if (health == 0)
        {

            animator.SetTrigger("Die");
            isDead = true;
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        animator.SetFloat("Movement", Mathf.Abs(movement.x));
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.y = -3.93f;
        }
        
    }
}
