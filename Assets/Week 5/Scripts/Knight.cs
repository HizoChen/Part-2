using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class Knight : MonoBehaviour
{
    Vector2 movement;
    Vector2 destination;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
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
        health = PlayerPrefs.GetFloat("currentHealth", maxHealth);
        SendMessage("SetHealth", health, SendMessageOptions.DontRequireReceiver);
        if (health == 0)
        {

            animator.SetTrigger("Death");
            isDead = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb . position + movement.normalized * speed * Time.deltaTime);
    }
    void Update()
    {
       
        if (isDead) return;
        if (Input.GetMouseButtonDown(0)&& !clickingOnSelf && ! EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
       animator.SetFloat("Movement",movement.magnitude);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("rightclick");
            animator.SetTrigger("Attack");
        }
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf |= true;
        TakeDamage(1);
        healthBar.TakeDamage(1);
        
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false;
    
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health,0,maxHealth);
        PlayerPrefs.SetFloat("currentHealth", health);
        if (health == 0)
        {

            animator.SetTrigger("Death");
            isDead = true;
        }
        else
        {
            animator.SetTrigger("TakeDamage");
            isDead= false;
        }
       
    }
 
}
