using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Animator cAnimator;

    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float atkCooldown = 0.0f;
    int atkTime = 0;

    public projectileBehavior ProjectilePrefab;
    public swordBehavior SwordPrefab;
    public Transform LaunchOffset;
    public Transform SwordOffset;
    public GameObject[] leftAlive;

    public int health;
    public int maxHealth;
    public int arrowAmmo;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        cAnimator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
        arrowAmmo = 3;
    }

    private void Update()
    {
        leftAlive = GameObject.FindGameObjectsWithTag("Enemy");
        var movement = Input.GetAxis("Horizontal");
        atkCooldown -= Time.deltaTime;

        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject Player in otherObjects) {
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
       
        if(knockbackCount <= 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            if(!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
            }
            if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            if(Input.GetButtonDown("Fire1") && arrowAmmo >= 1)
            {
                arrowAmmo--;
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            }
            if(Input.GetButtonDown("Fire2") && atkCooldown <= 0)
            {
                Instantiate(SwordPrefab, SwordOffset.position, transform.rotation);
                atkCooldown = 0.5f;
                cAnimator.SetTrigger("atk");
            }
        }
        else
        {
            if(knockFromRight)
            {
                transform.position += new Vector3(-knockback, knockback, 0);
            }
            else
            {
                transform.position += new Vector3(knockback, knockback, 0);
            }
            knockbackCount -= Time.deltaTime;
        }

        if(leftAlive.Length == 0){
           //SceneManager.LoadScene("bossBattle");
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene("bossBattle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemyProjectile")
        {
            Destroy(collision.gameObject);
            health--;
            knockbackCount = 0.6f;
            knockFromRight = true;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }
}