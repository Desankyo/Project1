using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShroom : MonoBehaviour
{
    public PlayerMover playerHealth;
    public PlayerMover enemyKnockback;
    public PlayerMover fromRight;
    public float moveSpeed = 1f;
    public float jumpHeight = 1f;
    public float changeDirectionTime = 5f;
    public float jumpTime = 2f;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float timer = 0f;
    public float damageToDeal = 0.5f;
    public int damage = 1;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            facingRight = !facingRight;
            timer = changeDirectionTime;
        }

        float horizontal = facingRight ? moveSpeed : -moveSpeed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            enemyKnockback.knockbackCount = 0.6f;
            if(collision.transform.position.x < transform.position.x)
            {
                fromRight.knockFromRight = true;
            }
            else
            {
                fromRight.knockFromRight = false;
            }
        }

        if(collision.gameObject.tag == "Projectile")
        {
            health--;
        }
          if(collision.gameObject.tag == "Sword")
        {
            health--;
        }
    }
}